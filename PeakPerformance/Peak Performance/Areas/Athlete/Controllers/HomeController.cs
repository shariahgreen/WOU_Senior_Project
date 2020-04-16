namespace Peak_Performance.Areas.Athlete.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Peak_Performance.DAL;
    using Peak_Performance.Models;
    using Peak_Performance.Models.ViewModels;

    [Authorize(Roles = "Athlete")]
    public class HomeController : Controller
    {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);
            AthleteProfileViewModel athlete = new AthleteProfileViewModel(temp.ID);
            return View("Index", athlete);
        }

        [HttpPost]
        public ActionResult FitBit(string steps, string miles, string calories, string floors, string sedentary)
        {
            ViewData["steps"] = steps;
            ViewData["miles"] = miles;
            ViewData["calories"] = calories;
            ViewData["floors"] = floors;
            ViewData["sedentary"] = sedentary;

            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);
            AthleteProfileViewModel athlete = new AthleteProfileViewModel(temp.ID);

            return View("Index", athlete);
        }
    }
}