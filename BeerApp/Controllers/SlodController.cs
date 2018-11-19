using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeerApp.DAL;
using BeerApp.Models;

namespace BeerApp.Controllers
{
    public class SlodController : Controller
    {
        private BeerContext db = new BeerContext();

        // GET: Slod
        public ActionResult Index()
        {
            return View(db.Slody.ToList());
        }

        // GET: Slod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slod slod = db.Slody.Find(id);
            if (slod == null)
            {
                return HttpNotFound();
            }
            return View(slod);
        }

        // GET: Slod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlodID,NazwaSlodu,Barwa,Ekstraktywnosc")] Slod slod)
        {
            if (ModelState.IsValid)
            {
                db.Slody.Add(slod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slod);
        }

        // GET: Slod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slod slod = db.Slody.Find(id);
            if (slod == null)
            {
                return HttpNotFound();
            }
            return View(slod);
        }

        // POST: Slod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlodID,NazwaSlodu,Barwa,Ekstraktywnosc")] Slod slod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slod);
        }

        // GET: Slod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slod slod = db.Slody.Find(id);
            if (slod == null)
            {
                return HttpNotFound();
            }
            return View(slod);
        }

        // POST: Slod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slod slod = db.Slody.Find(id);
            db.Slody.Remove(slod);
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
