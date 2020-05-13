
﻿ namespace Peak_Performance.Areas.Coach.Controllers {
    
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Peak_Performance.DAL;
    using Peak_Performance.Models;

    [Authorize(Roles = "Coach")]
    public class HomeController : Controller
    {
        private PeakPerformanceContext db = new PeakPerformanceContext();

        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);
            CoachProfileViewModel coach = new CoachProfileViewModel(temp.ID);
            return View("Index", coach);
        }

        // GET: /AddAthlete
        public ActionResult AddAthlete()
        {
            string id = User.Identity.GetUserId();
            Person temp = db.Persons.FirstOrDefault(p => p.ASPNetIdentityID == id);

            CoachProfileViewModel coach = new CoachProfileViewModel(temp.ID);
            //    {
            //        teamList = new SelectList(db.Teams.Where(item => item.CoachID == temp.ID))
            //};
            ViewBag.ID = new SelectList(db.Persons.Select(r => r.Athlete), "ID", "FirstName");
            ViewBag.TeamID = new SelectList(db.Teams.Where(item => item.CoachID == temp.ID), "ID", "TeamName");
            return View("AddAthlete", coach);
        }

        // POST: /AddAthlete
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddAthlete(CoachProfileViewModel vm) {
            if(ModelState.IsValid) {
                Athlete a = db.Athletes.FirstOrDefault(x => x.ID == vm.athItem.ID);
                a.TeamID = vm.teamItem.ID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Persons, "ID", "FirstName", vm.athItem.ID);
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "TeamName", vm.teamItem.ID);
            return View("Index");
        }
    }
}