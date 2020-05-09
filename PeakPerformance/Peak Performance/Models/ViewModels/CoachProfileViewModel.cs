using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;

namespace Peak_Performance.Models
{
    public class CoachProfileViewModel
    {
        private readonly PeakPerformanceContext db = new PeakPerformanceContext();

        public CoachProfileViewModel(int id)
        {
            coach = db.Coaches.Find(id);
            teams = db.Teams.Where(t => t.CoachID == id).ToList();
            teamList = new SelectList(teams);
            CoachProfileId = coach.ID;
            athletes = new List<Athlete>();
            foreach (Team team in teams)
            {
                IEnumerable<Athlete> athletelist = db.Athletes.Where(a => a.TeamID == team.ID).ToList();
                if (athletelist != null)
                {
                    athletes.AddRange(athletelist);
                }
            }
            athList = new SelectList(athletes);
        }

        public int CoachProfileId { get; set; }
        public virtual IEnumerable<Team> teams { get; set; }
        public virtual Coach coach { get; set; }
        public virtual List<Athlete> athletes { get; set; }
        public IEnumerable<SelectListItem> teamList { get; set; }
        public Team teamItem { get; set; }
        public IEnumerable<SelectListItem> athList { get; set; }
        public Team athItem { get; set; }
    }
}