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
    public class TablevenuesController : Controller
    {
        private readonly EventManagementSystemEntities db = new EventManagementSystemEntities();

        // GET: Tablevenues
        public ActionResult Index()
        {
            return View(db.Tablevenues.ToList());
        }

        // GET: Tablevenues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablevenue tablevenue = db.Tablevenues.Find(id);
            if (tablevenue == null)
            {
                return HttpNotFound();
            }
            return View(tablevenue);
        }

        // GET: Tablevenues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tablevenues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "venueid,venue,events1")] Tablevenue tablevenue)
        {
            if (ModelState.IsValid)
            {
                db.Tablevenues.Add(tablevenue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablevenue);
        }

        // GET: Tablevenues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablevenue tablevenue = db.Tablevenues.Find(id);
            if (tablevenue == null)
            {
                return HttpNotFound();
            }
            return View(tablevenue);
        }

        // POST: Tablevenues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "venueid,venue,events1")] Tablevenue tablevenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablevenue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablevenue);
        }

        // GET: Tablevenues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablevenue tablevenue = db.Tablevenues.Find(id);
            if (tablevenue == null)
            {
                return HttpNotFound();
            }
            return View(tablevenue);
        }

        // POST: Tablevenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tablevenue tablevenue = db.Tablevenues.Find(id);
            db.Tablevenues.Remove(tablevenue);
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
