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
    public class ChmielController : Controller
    {
        private BeerContext db = new BeerContext();

        // GET: Chmiel
        public ActionResult Index()
        {
            return View(db.Chmiele.ToList());
        }

        // GET: Chmiel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chmiel chmiel = db.Chmiele.Find(id);
            if (chmiel == null)
            {
                return HttpNotFound();
            }
            return View(chmiel);
        }

        // GET: Chmiel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chmiel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChmielID,NazwaChmielu,AlfaKwasy")] Chmiel chmiel)
        {
            if (ModelState.IsValid)
            {
                db.Chmiele.Add(chmiel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chmiel);
        }

        // GET: Chmiel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chmiel chmiel = db.Chmiele.Find(id);
            if (chmiel == null)
            {
                return HttpNotFound();
            }
            return View(chmiel);
        }

        // POST: Chmiel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChmielID,NazwaChmielu,AlfaKwasy")] Chmiel chmiel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chmiel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chmiel);
        }

        // GET: Chmiel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chmiel chmiel = db.Chmiele.Find(id);
            if (chmiel == null)
            {
                return HttpNotFound();
            }
            return View(chmiel);
        }

        // POST: Chmiel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chmiel chmiel = db.Chmiele.Find(id);
            db.Chmiele.Remove(chmiel);
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
