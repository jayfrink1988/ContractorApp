using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContractorApp.Content;

namespace ContractorApp.Controllers
{
    public class ContractorsController : Controller
    {
        private ContractorEntities1 db = new ContractorEntities1();

        // GET: Contractors
        public ActionResult Index()
        {
            var contractors = db.Contractors.Include(c => c.Employer).Include(c => c.Location).Include(c => c.Program).Include(c => c.Supervisor).Include(c => c.Institution);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }

        public ActionResult Program(int? id)
        {
            var contractors = db.Contractors.Include(c => c.Employer).Include(c => c.Location).Include(c => c.Program).Where(s => s.ProgramID == id).Include(c => c.Supervisor);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }
        public ActionResult Agency(int? id)
        {
            var contractors = db.Contractors.Include(c => c.Employer).Where(s => s.EmployerID == id).Include(c => c.Location).Include(c => c.Program).Include(c => c.Supervisor);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }
        public ActionResult Location(int? id)
        {
            var contractors = db.Contractors.Include(c => c.Employer).Where(s => s.EmployerID == id).Include(c => c.Location).Where(c => c.LocationID == id).Include(c => c.Program).Include(c => c.Supervisor);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }
        public ActionResult Supervisor(int? id)
        {
            var contractors = db.Contractors.Include(c => c.Employer).Where(s => s.EmployerID == id).Include(c => c.Location).Include(c => c.Program).Include(c => c.Supervisor).Where(c => c.SupervisorID == id);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }
        public ActionResult Institution(int? id)
        {
            var contractors = db.Contractors.Include(c => c.Employer).Include(c => c.Location).Include(c => c.Program).Include(c => c.Supervisor).Where(c => c.InstitutionID == id);
            return View(contractors.OrderBy(c => c.Lname).ToList());
        }

        // GET: Contractors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = db.Contractors.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            return View(contractor);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "EmployerName");
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            //ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "SupLName");
            ViewBag.InstitutionID = new SelectList(db.Institutions, "InstitutionID", "InstitutionName");
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "FullName");
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractorID,Lname,Fname,Phone,ProgramID,SupervisorID,EmployerID,LocationID,Active,work_email,personal_email,InstitutionID")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                db.Contractors.Add(contractor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "EmployerName", contractor.EmployerID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", contractor.LocationID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", contractor.ProgramID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "SupLName", contractor.SupervisorID);
            ViewBag.InstitutionID = new SelectList(db.Institutions, "InstitutionID", "InstitutionName", contractor.InstitutionID);
            return View(contractor);
        }

        // GET: Contractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = db.Contractors.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "EmployerName", contractor.EmployerID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", contractor.LocationID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", contractor.ProgramID);
            //ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "SupLName", contractor.SupervisorID);
            ViewBag.InstitutionID = new SelectList(db.Institutions, "InstitutionID", "InstitutionName", contractor.InstitutionID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "FullName", contractor.SupervisorID);
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractorID,Lname,Fname,Phone,ProgramID,SupervisorID,EmployerID,LocationID,Active,work_email,personal_email,InstitutionID")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "EmployerName", contractor.EmployerID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", contractor.LocationID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", contractor.ProgramID);
            ViewBag.SupervisorID = new SelectList(db.Supervisors, "SupervisorID", "SupLName", contractor.SupervisorID);
            ViewBag.InstitutionID = new SelectList(db.Institutions, "InstitutionID", "InstitutionName", contractor.InstitutionID);
            return View(contractor);
        }

        // GET: Contractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = db.Contractors.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contractor contractor = db.Contractors.Find(id);
            db.Contractors.Remove(contractor);
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
