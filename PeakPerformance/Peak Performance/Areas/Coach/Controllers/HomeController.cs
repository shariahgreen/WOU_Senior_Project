
namespace Peak_Performance.Areas.Coach.Controllers {
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Peak_Performance.DAL;
    using Peak_Performance.Models;


    [Authorize(Roles = "Coach")]
    public class HomeController : Controller {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        public ActionResult Index() {
            string id = User.Identity.GetUserId();
            Coach temp = db.Coaches.FirstOrDefault(p => p.UserId == id);
            CoachProfileViewModel coach = new CoachProfileViewModel(temp.CoachId);
            return View("Index", coach);
        }
    }
}