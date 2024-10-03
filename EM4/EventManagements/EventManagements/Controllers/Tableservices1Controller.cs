using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventManagements.Models;

namespace EventManagements.Controllers
{
    public class Tableservices1Controller : Controller
    {
        private readonly EventManagementSystemEntities db = new EventManagementSystemEntities();

        // GET: Tableservices1
        public ActionResult Index()
        {
            return View(db.Tableservices.ToList());
        }

        // GET: Tableservices1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableservice tableservice = db.Tableservices.Find(id);
            if (tableservice == null)
            {
                return HttpNotFound();
            }
            return View(tableservice);
        }

        // GET: Tableservices1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tableservices1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serviceid,servicename,servicecharge")] Tableservice tableservice)
        {
            if (ModelState.IsValid)
            {
                db.Tableservices.Add(tableservice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableservice);
        }

        // GET: Tableservices1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableservice tableservice = db.Tableservices.Find(id);
            if (tableservice == null)
            {
                return HttpNotFound();
            }
            return View(tableservice);
        }

        // POST: Tableservices1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "serviceid,servicename,servicecharge")] Tableservice tableservice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableservice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableservice);
        }

        // GET: Tableservices1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableservice tableservice = db.Tableservices.Find(id);
            if (tableservice == null)
            {
                return HttpNotFound();
            }
            return View(tableservice);
        }

        // POST: Tableservices1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tableservice tableservice = db.Tableservices.Find(id);
            db.Tableservices.Remove(tableservice);
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
