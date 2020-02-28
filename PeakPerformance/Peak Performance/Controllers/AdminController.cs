using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Peak_Performance.Models;

namespace Peak_Performance.Controllers
{
    public class AdminController : Controller
    {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AllTeams()
        {
            var teams = db.Teams.ToList();
            return View(teams);
        }

        public ActionResult AllAthletes()
        {
            var athletes = db.Athletes.ToList();
            return View(athletes);
        }

        public ActionResult AllCoaches()
        {
            var coaches = db.Coaches.ToList();
            return View(coaches);
        }
    }
}