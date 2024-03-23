using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emp_CRUD_DbFirst.Models;

namespace Emp_CRUD_DbFirst.Controllers
{
    public class EmpController : Controller
    {
        private Emp_CRUD_DbEntities db = new Emp_CRUD_DbEntities();

        // GET: Emp
        public ActionResult Index()
        {
            return View(db.Emp_Details.ToList());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Details emp_Details = db.Emp_Details.Find(id);
            if (emp_Details == null)
            {
                return HttpNotFound();
            }
            return View(emp_Details);
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Emp_Name,Emp_Email_ID,Emp_Contact_No,Emp_Salary,Emp_City")] Emp_Details emp_Details)
        {
            if (ModelState.IsValid)
            {
                db.Emp_Details.Add(emp_Details);
                db.SaveChanges();
                TempData["AlertMsg"] = "Emp Details Created Successfully!";
                return RedirectToAction("Index");
            }

            return View(emp_Details);
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Details emp_Details = db.Emp_Details.Find(id);
            if (emp_Details == null)
            {
                return HttpNotFound();
            }
            return View(emp_Details);
        }

        // POST: Emp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Emp_Name,Emp_Email_ID,Emp_Contact_No,Emp_Salary,Emp_City")] Emp_Details emp_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_Details).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMsg"] = " Emp Details Updated Successfully !";
                return RedirectToAction("Index");
            }
            return View(emp_Details);
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Details emp_Details = db.Emp_Details.Find(id);
            if (emp_Details == null)
            {
                return HttpNotFound();
            }
            return View(emp_Details);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp_Details emp_Details = db.Emp_Details.Find(id);
            db.Emp_Details.Remove(emp_Details);
            db.SaveChanges();
            TempData["AlertMsg"] = " Emp Details Deleted Successfully !";
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
