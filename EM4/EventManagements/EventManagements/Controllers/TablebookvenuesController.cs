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
    public class TablebookvenuesController : Controller
    {
        private readonly EventManagementSystemEntities db = new EventManagementSystemEntities();

        // GET: Tablebookvenues
        public ActionResult Index()
        {
            return View(db.Tablebookvenues.ToList());
        }

        // GET: Tablebookvenues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablebookvenue tablebookvenue = db.Tablebookvenues.Find(id);
            if (tablebookvenue == null)
            {
                return HttpNotFound();
            }
            return View(tablebookvenue);
        }

        // GET: Tablebookvenues/Create
        public ActionResult Create()
        {
            return View();
        }

      

        // POST: Tablebookvenues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,mobilenumber,event1,venue,eventdate,requirements")] Tablebookvenue tablebookvenue)
        {
            if (ModelState.IsValid)
            {
                db.Tablebookvenues.Add(tablebookvenue);
                db.SaveChanges();
                return RedirectToAction("paymentpage");
            }

            return View(tablebookvenue);
        }

        // GET: Tablebookvenues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablebookvenue tablebookvenue = db.Tablebookvenues.Find(id);
            if (tablebookvenue == null)
            {
                return HttpNotFound();
            }
            return View(tablebookvenue);
        }

        // POST: Tablebookvenues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,mobilenumber,event1,venue,eventdate,requirements")] Tablebookvenue tablebookvenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablebookvenue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablebookvenue);
        }

        // GET: Tablebookvenues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablebookvenue tablebookvenue = db.Tablebookvenues.Find(id);
            if (tablebookvenue == null)
            {
                return HttpNotFound();
            }
            return View(tablebookvenue);
        }

        // POST: Tablebookvenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tablebookvenue tablebookvenue = db.Tablebookvenues.Find(id);
            db.Tablebookvenues.Remove(tablebookvenue);
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

        public ActionResult Paymentpage()
        {
            return View();
        }
        public ActionResult Orderbooked()
        {
            return View();
        }
    }
}
