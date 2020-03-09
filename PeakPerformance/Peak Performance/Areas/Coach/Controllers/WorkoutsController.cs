using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peak_Performance.DAL;
using Peak_Performance.Models;

namespace Peak_Performance.Areas.Coach
{
    [Authorize(Roles = "Coach")]
    public class WorkoutsController : Controller
    {

        private PeakPerformanceContext db = new PeakPerformanceContext();

        // GET: Coach/Workouts
        public ActionResult Index()
        {
            var workouts = db.Workouts.Include(w => w.Team);
            return View(workouts.ToList());
        }
        public ActionResult SearchMain(string exercise)
        {
            ViewBag.MuscleGroupsId = new SelectList(db.MuscleGroups, "MuscleGroupsId", "Name");
            IEnumerable<Peak_Performance.Models.Exercis> list = db.Exercises.Where(p => p.Name.Contains(exercise)).ToList();
            return View(list);
        }

        public JsonResult SearchByMuscle(string MuscleGroupsId)
        {
            ViewBag.MuscleGroupsId = new SelectList(db.MuscleGroups, "MuscleGroupsId", "Name");
            //IEnumerable<string> list = new IEnumerable<string>();
            IEnumerable<string> result = db.ExcerciseMuscleGroups.Where(p => p.MuscleGroup.Name.Contains(MuscleGroupsId)).Select(p => p.Exercis.Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Coach/Workouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Coach/Workouts/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: Coach/Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutsId,WorkoutDate,TeamID")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamId", "TeamName", workout.TeamID);
            return View(workout);
        }

        // GET: Coach/Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamId", "TeamName", workout.TeamID);
            return View(workout);
        }

        // POST: Coach/Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkoutsId,WorkoutDate,TeamID")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamId", "TeamName", workout.TeamID);
            return View(workout);
        }

        // GET: Coach/Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Coach/Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
