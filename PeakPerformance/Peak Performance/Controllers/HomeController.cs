using Microsoft.AspNet.Identity;
using Peak_Performance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;

namespace Peak_Performance.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeakPerformanceContext db = new PeakPerformanceContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We're Here to Help, Contact Us";

            return View();
        }
    }
}