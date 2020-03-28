using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Microsoft.AspNet.Identity;

namespace Peak_Performance.Models
{
    public class WorkoutCreationViewModel
    {
        private readonly PeakPerformanceContext db = new PeakPerformanceContext();
        public WorkoutCreationViewModel(Coach coach, int team, DateTime date)
        {
            Date = date;
            Team = db.Teams.FirstOrDefault(t => t.TeamId == team);
            Coach = coach;
            NewWorkout = new Workout();
            NewWorkout.Team = Team;
            NewWorkout.TeamID = Team.TeamId;
            NewWorkout.WorkoutDate = Date;
            Complexes = db.Complexes.Where(c => c.WorkoutID == NewWorkout.WorkoutsId).ToList();
            foreach (var c in Complexes)
            {
                foreach (var i in db.ComplexItems.Where(i => i.ComplexId == c.ComplexesId))
                {
                    ComplexItems.Append(i);
                }
            }
        }

        public int addComplex()
        {
            Complex temp = new Complex();
            temp.WorkoutID = NewWorkout.WorkoutsId;
            Complexes.Append(temp);

            return temp.ComplexesId;
        }

        public void addComplexItem(int ComplexId, Exercis exercise, int? reps, int? sets, double? weight, double? distance, double? speed, TimeSpan? time)
        {
            ComplexItem item = new ComplexItem();
            item.ComplexId = ComplexId;
            item.ExerciseID = exercise.ExercisesId;
            item.ComplexReps = reps;
            item.ComplexSets = sets;
            item.LiftWeight = weight;
            item.RunDistance = distance;
            item.RunSpeed = speed;
            item.RunTime = time;
            ComplexItems.Append(item);
            return;
        }

        public void submitWorkout()
        {
            db.Workouts.Add(NewWorkout);

            foreach (var c in Complexes)
            {
                db.Complexes.Add(c);
            }

            foreach (var i in ComplexItems)
            {
                db.ComplexItems.Add(i);
            }

            db.SaveChanges();

            return;
        }
        public Peak_Performance.Models.Workout NewWorkout { get; set; }
        public Peak_Performance.Models.Coach Coach { get; set; }
        public Peak_Performance.Models.Team Team { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Peak_Performance.Models.Exercis> Exercises { get; set; }
        public IEnumerable<Peak_Performance.Models.Complex> Complexes { get; set; }
        public IEnumerable<Peak_Performance.Models.ComplexItem> ComplexItems { get; set; }

    }
}