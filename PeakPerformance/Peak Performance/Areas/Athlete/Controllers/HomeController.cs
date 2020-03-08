using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Peak_Performance.Models;

namespace Peak_Performance.Areas.Athlete.Controllers {

    [Authorize(Roles = "Athlete")]
    public class HomeController : Controller {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        public ActionResult Index() {
            return View();
        }
    }
}