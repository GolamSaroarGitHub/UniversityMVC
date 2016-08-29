using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpireUniversity.Models;

namespace EmpireUniversity.Controllers
{
    public class AllocateRoomController : Controller
    {
        private EmpiresUniversityEntities db = new EmpiresUniversityEntities();

        // GET: /AllocateRoom/
        public ActionResult Index()
        {
            return View(db.Allocates.ToList());
        }

        // GET: /AllocateRoom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate allocate = db.Allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // GET: /AllocateRoom/Create
        public ActionResult Create()
        {


            ViewBag.Departments = new SelectList(db.Departments, "DepartmentName", "DepartmentName");
            ViewBag.Courses = new SelectList(db.Courses, "CourseName", "CourseName");
            ViewBag.Rooms = new SelectList(db.Rooms, "RoomNo", "RoomNo");
            ViewBag.Days = new SelectList(db.Days, "DayName", "DayName");


            return View();
        }

        // POST: /AllocateRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Department,Course,RoomNo,Day,FromTime,ToTime,FromTimeHH,FromTimeMM,ToTimeHH,ToTimeMM,FromTimeAMPM,ToTimeAMPM")] Allocate allocate)
        {
            if (allocate.FromTimeAMPM == "PM")
            {
                

            }



            if (ModelState.IsValid)
            {
                db.Allocates.Add(allocate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allocate);
        }

        // GET: /AllocateRoom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate allocate = db.Allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // POST: /AllocateRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Department,Course,RoomNo,Day,FromTime,ToTime,FromTimeHH,FromTimeMM,ToTimeHH,ToTimeMM,FromTimeAMPM,ToTimeAMPM")] Allocate allocate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allocate);
        }

        // GET: /AllocateRoom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate allocate = db.Allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // POST: /AllocateRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allocate allocate = db.Allocates.Find(id);
            db.Allocates.Remove(allocate);
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


        public ActionResult ShowAllocation()
        {
            return View();
        }
    }
}
