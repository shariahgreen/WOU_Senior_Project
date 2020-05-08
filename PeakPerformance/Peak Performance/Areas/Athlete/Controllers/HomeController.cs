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

        [Authorize]
        public ActionResult Index()
        {
            //getting id for everything
            string ID = User.Identity.GetUserId();
            int PersonID = db.Persons.Where(r => r.ASPNetIdentityID == ID).Select(r => r.ID).First();

            //logging height, weight, age, and gender of person
            ViewData["Height"] = db.Athletes.Where(r => r.Person.ID == PersonID).Select(r => r.Height).First();
            ViewData["Weight"] = db.Athletes.Where(r => r.Person.ID == PersonID).Select(r => r.Weight).First();
            ViewData["Age"] = db.Athletes.Where(r => r.Person.ID == PersonID).Select(r => r.DOB).First();
            ViewData["Sex"] = db.Athletes.Where(r => r.Person.ID == PersonID).Select(r => r.Sex).First();

            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);
            AthleteProfileViewModel athlete = new AthleteProfileViewModel(temp.ID);
            return View("Index", athlete);
        }

        [HttpPost]
        [Authorize]
        public ActionResult FitBit(string userID, string token)
        {
            //getting id for everything
            string ID = User.Identity.GetUserId();
            int PersonID = db.Persons.Where(r => r.ASPNetIdentityID == ID).Select(r => r.ID).First();

            //adding token and userID
            Person user = db.Persons.Find(PersonID);
            user.Athlete.FitBitUserID = userID;
            user.Athlete.FitBitAccessToken = token;
            db.SaveChanges();

            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);
            AthleteProfileViewModel athlete = new AthleteProfileViewModel(temp.ID);

            return View("Index", athlete);
        }

        public ActionResult HelpAndHints()
        {
            return View();
        }
    }
}