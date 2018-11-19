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
    public class DrozdzeController : Controller
    {
        private BeerContext db = new BeerContext();

        // GET: Drozdze
        public ActionResult Index()
        {
            return View(db.Drozdzes.ToList());
        }

        // GET: Drozdze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drozdze drozdze = db.Drozdzes.Find(id);
            if (drozdze == null)
            {
                return HttpNotFound();
            }
            return View(drozdze);
        }

        // GET: Drozdze/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drozdze/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrozdzeID,Flokulacja,Fermentacja,Toleranjca,Odfermentowanie")] Drozdze drozdze)
        {
            if (ModelState.IsValid)
            {
                db.Drozdzes.Add(drozdze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drozdze);
        }

        // GET: Drozdze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drozdze drozdze = db.Drozdzes.Find(id);
            if (drozdze == null)
            {
                return HttpNotFound();
            }
            return View(drozdze);
        }

        // POST: Drozdze/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrozdzeID,Flokulacja,Fermentacja,Toleranjca,Odfermentowanie")] Drozdze drozdze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drozdze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drozdze);
        }

        // GET: Drozdze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drozdze drozdze = db.Drozdzes.Find(id);
            if (drozdze == null)
            {
                return HttpNotFound();
            }
            return View(drozdze);
        }

        // POST: Drozdze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drozdze drozdze = db.Drozdzes.Find(id);
            db.Drozdzes.Remove(drozdze);
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
