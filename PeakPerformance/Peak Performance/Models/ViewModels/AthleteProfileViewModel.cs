using Peak_Performance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peak_Performance.Models.ViewModels
{
    public class AthleteProfileViewModel        
    {
        private readonly PeakPerformanceContext db = new PeakPerformanceContext();

        public AthleteProfileViewModel(int id)
        {
            athlete = db.Athletes.Find(id);

            int? athleteTeamID = db.Athletes.Find(id).TeamID;

            //select list of workout in the past
            pastWorkoutLists = db.Workouts.Where(p => p.TeamID == athleteTeamID && p.WorkoutDate < DateTime.Today).ToList();           
            pastWorkoutDate = pastWorkoutLists.Select(p => ConvertToDate(p.WorkoutDate)).ToList();

            //select list of workout today and future
            upcomingWorkoutLists = db.Workouts.Where(p => p.TeamID == athleteTeamID && p.WorkoutDate >= DateTime.Today).ToList();
            upcomingWorkoutDate = upcomingWorkoutLists.Select(p => ConvertToDate(p.WorkoutDate)).ToList();
        }

        public AthleteProfileViewModel()
        {
            
        }

        public string ConvertToDate(DateTime s)
        {
            return s.ToString("MM-dd-yyyy");
        }
        public virtual Athlete athlete { get; set; }
        public virtual Person person { get; set; }

        public virtual IEnumerable<Workout> pastWorkoutLists { get; set; }

        public virtual List<string> pastWorkoutDate { get; set; }

        public virtual IEnumerable<Workout> upcomingWorkoutLists { get; set; }

        public virtual List<string> upcomingWorkoutDate { get; set; }
    }
}