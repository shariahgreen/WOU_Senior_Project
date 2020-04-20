using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Microsoft.AspNet.Identity;

namespace Peak_Performance.Models.ViewModels
{
    public class WorkoutsViewModel
    {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        public DateTime date { get; set; }

        public int team {get; set;}
        
        public List<ComplexViewModel> complexes { get; set; }

        /*public WorkoutsViewModel(DateTime d, int t, List<ComplexViewModel> c)
        {
            this.date = d;
            this.team = t;
            this.complexes = c;
        }*/
       public List<int> CountExercises ()
        {
            List<int> exercises = new List<int>();
            for (int i = 0; i < this.complexes.Count(); i++)
            {
                exercises.Add(this.complexes[i].complex.Count());
            }
            return exercises;
        }

        public Peak_Performance.Models.Workout createWorkout()
        {
            try
            {
                Peak_Performance.Models.Workout workout = new Workout();
                workout.Team = db.Teams.Find(this.team);
                workout.WorkoutDate = this.date;

                foreach (ComplexViewModel comp in this.complexes)
                {
                    Peak_Performance.Models.Complex complex = new Complex();
                    complex.Workout = workout;
                    foreach (ExerciseViewModel ex in comp.complex)
                    {
                        Peak_Performance.Models.ComplexItem item = new ComplexItem();
                        item.Complex = complex;
                        item.Exercis = db.Exercises.FirstOrDefault(e => e.Name == ex.name);
                        item.ComplexReps = ex.reps;
                        item.ComplexSets = ex.sets;
                        item.LiftWeight = ex.weight;
                        item.RunDistance = ex.distance;
                        item.RunSpeed = ex.speed;
                        item.RunTime = ex.time;
                        //db.ComplexItems.Add(item);
                    }
                    //db.Complexes.Add(complex);
                }
                //db.Workouts.Add(workout);
                //db.SaveChanges();
                return workout;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

  
    public class ComplexViewModel
    {
        public List<ExerciseViewModel> complex { get; set; }

        /*public ComplexViewModel(List<ExerciseViewModel> ex)
        {
            this.complex = ex;
        }*/
        
    }

    public class ExerciseViewModel
    {
        public string name { get; set; }
        public int? reps { get; set; }
        public int? sets { get; set; }
        public double? weight { get; set; }
        public TimeSpan? time { get; set; }
        public double? speed { get; set; }
        public double? distance { get; set; }
        /*public ExerciseViewModel(string Name, string Reps, string Sets, string Weight, string Time, string Speed, string Distance)
        {
            this.name = Name;
            this.reps = Reps;
            this.sets = Sets;
            this.weight = Weight;
            this.time = Time;
            this.speed = Speed;
            this.distance = Distance;
        }*/
    }
}