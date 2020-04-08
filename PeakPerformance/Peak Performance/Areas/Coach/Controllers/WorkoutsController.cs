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
using Microsoft.AspNet.Identity;
using System.Reflection;

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
            string id = User.Identity.GetUserId();
            Peak_Performance.Models.Coach temp = db.Coaches.FirstOrDefault(p => p.Person.ASPNetIdentityID == id);
            ViewBag.MuscleGroupsId = new SelectList(db.MuscleGroups, "MuscleGroupsId", "Name");
            ViewBag.TeamList = new SelectList(db.Teams.Where(t => t.CoachID == temp.ID), "ID", "TeamName");
            IEnumerable<Peak_Performance.Models.Exercis> list = db.Exercises.Where(p => p.Name.Contains(exercise)).ToList();
            return View(list);

        }
        //[RequireRouteValues(new[] { "TeamList", "Date" })]
        //public JsonResult CreateWorkout(int TeamList, string Date)
        [HttpPost]
        public void CreateWorkout()
        {
            string id = User.Identity.GetUserId();
            Peak_Performance.Models.Coach temp = db.Coaches.FirstOrDefault(p => p.Person.ASPNetIdentityID == id);
            //DateTime dateTime = DateTime.Parse(Date);
            //Peak_Performance.Models.WorkoutCreationViewModel WorkoutCreation = new WorkoutCreationViewModel(temp, TeamList, dateTime);
            //ViewBag.MuscleGroupsId = new SelectList(db.MuscleGroups, "MuscleGroupsId", "Name");
            
            //ViewBag.TeamList = new SelectList(db.Teams.Where(t => t.CoachId == temp.CoachId), "TeamId", "TeamName");
            //ViewBag.WorkoutCreation = WorkoutCreation;
            //return Json(WorkoutCreation, JsonRequestBehavior.AllowGet);
            return;
        }

        //public JsonResult CreateComplex (int WorkoutId)
        //{
//
  //          return; //Json();
    //    }

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
            string id = User.Identity.GetUserId();
            //Peak_Performance.Models.Coach temp = db.Coaches.FirstOrDefault(p => p.UserId == id);
            //ViewBag.TeamID = new SelectList(db.Teams.Where(t => t.Coach == temp), "TeamId", "TeamName");
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


    public class RequireRouteValuesAttribute : ActionMethodSelectorAttribute
    {
        public RequireRouteValuesAttribute(string[] valueNames)
        {
            ValueNames = valueNames;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            bool contains = false;
            foreach (var value in ValueNames)
            {
                contains = controllerContext.HttpContext.Request[value] != null;
                if (!contains) break;
            }
            return contains;
        }

        public string[] ValueNames { get; private set; }
    }
}
