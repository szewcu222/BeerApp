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
    public class RecepturaController : Controller
    {
        private BeerContext db = new BeerContext();

        // GET: Receptura
        public ActionResult Index()
        {
            return View(db.Receptury.ToList());
        }

        // GET: Receptura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptura receptura = db.Receptury.Find(id);
            if (receptura == null)
            {
                return HttpNotFound();
            }
            return View(receptura);
        }

        // GET: Receptura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receptura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecepturaID,NazwaReceptury")] Receptura receptura)
        {
            if (ModelState.IsValid)
            {
                db.Receptury.Add(receptura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receptura);
        }

        // GET: Receptura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptura receptura = db.Receptury.Find(id);
            if (receptura == null)
            {
                return HttpNotFound();
            }
            return View(receptura);
        }

        // POST: Receptura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecepturaID,NazwaReceptury")] Receptura receptura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receptura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receptura);
        }

        // GET: Receptura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptura receptura = db.Receptury.Find(id);
            if (receptura == null)
            {
                return HttpNotFound();
            }
            return View(receptura);
        }

        // POST: Receptura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receptura receptura = db.Receptury.Find(id);
            db.Receptury.Remove(receptura);
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
