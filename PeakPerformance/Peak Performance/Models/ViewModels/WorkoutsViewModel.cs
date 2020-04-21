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
                workout.TeamID = db.Teams.Find(this.team).ID;
                workout.WorkoutDate = this.date;

                List<Complex> complexes = new List<Complex>();
                foreach (ComplexViewModel comp in this.complexes)
                {
                    Peak_Performance.Models.Complex complex = new Complex();
                    complex.Workout = workout;
                    List<ComplexItem> complexItems = new List<ComplexItem>();
                    foreach (ExerciseViewModel ex in comp.complex)
                    {
                        if (db.Exercises.FirstOrDefault(e => e.Name == ex.name) != null)
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
                            complexItems.Add(item);
                            db.ComplexItems.Add(item);
                        }
                        else
                        {
                            //right now we are only creating the complex item if the exercise already exists in the database
                            //handle if we don't have the specified exercise
                            //maybe add a name attribute to complex items, set name == name if we dont have the exercise => no link to exercise info
                        }
                    }
                    complex.ComplexItems = complexItems;
                    complexes.Add(complex);
                    db.Complexes.Add(complex);
                }
                workout.Complexes = complexes;
                db.Workouts.Add(workout);
                db.SaveChanges();
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