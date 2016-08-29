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
    public class StudentController : Controller
    {
        private EmpiresUniversityEntities db = new EmpiresUniversityEntities();

        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentName", "DepartmentName");

            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Email,ContactNo,Date,Address,Department")] Student student)
        {
            
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentName", "DepartmentName");
            
            //DateTime date=new DateTime();
            string year = DateTime.Now.Year.ToString();
            string RNo = student.Department + "-" + year;



            int i = 1;
            List<Student> stdList= db.Students.ToList();

            foreach (var item in stdList)
            {
                if ((item.Department == student.Department))
                {
                    i ++;

                }
            }


//var departments = db.Students.Where(std=>std.Department==student.Department).ToList();

           string countID = "";
          //  if(departments.Count>9)
            if(i>9)
                countID = "0" + i.ToString();
            if(i<=9)
                countID = "00" + i.ToString();

            string rid = student.Department.ToString() + "-" + year + "-" + countID;
            ViewBag.m = rid;
            student.RegistrationNO =rid;
   
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,RegistrationNO,Name,Email,ContactNo,Date,Address,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
