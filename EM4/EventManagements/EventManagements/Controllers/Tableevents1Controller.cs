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
    public class Tableevents1Controller : Controller
    {
        private readonly EventManagementSystemEntities db = new EventManagementSystemEntities();

        // GET: Tableevents1
        public ActionResult Index()
        {
            return View(db.Tableevents.ToList());
        }

        // GET: Tableevents1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableevent tableevent = db.Tableevents.Find(id);
            if (tableevent == null)
            {
                return HttpNotFound();
            }
            return View(tableevent);
        }

        // GET: Tableevents1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tableevents1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventid,eventname,eventdate")] Tableevent tableevent)
        {
            if (ModelState.IsValid)
            {
                db.Tableevents.Add(tableevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableevent);
        }

        // GET: Tableevents1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableevent tableevent = db.Tableevents.Find(id);
            if (tableevent == null)
            {
                return HttpNotFound();
            }
            return View(tableevent);
        }

        // POST: Tableevents1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventid,eventname,eventdate")] Tableevent tableevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableevent);
        }

        // GET: Tableevents1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tableevent tableevent = db.Tableevents.Find(id);
            if (tableevent == null)
            {
                return HttpNotFound();
            }
            return View(tableevent);
        }

        // POST: Tableevents1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tableevent tableevent = db.Tableevents.Find(id);
            db.Tableevents.Remove(tableevent);
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
