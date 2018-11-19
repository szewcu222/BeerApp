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
    public class StylController : Controller
    {
        private BeerContext db = new BeerContext();

        // GET: Styl
        public ActionResult Index()
        {
            return View(db.Style.ToList());
        }

        // GET: Styl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Styl styl = db.Style.Find(id);
            if (styl == null)
            {
                return HttpNotFound();
            }
            return View(styl);
        }

        // GET: Styl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Styl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StylID,NazwaStylu,Kod,OGmin,OGmax,FGmin,FGmax,ABVmin,ABVmax,IBUmin,IBUmax,EBCmin,EBCmax")] Styl styl)
        {
            if (ModelState.IsValid)
            {
                db.Style.Add(styl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(styl);
        }

        // GET: Styl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Styl styl = db.Style.Find(id);
            if (styl == null)
            {
                return HttpNotFound();
            }
            return View(styl);
        }

        // POST: Styl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StylID,NazwaStylu,Kod,OGmin,OGmax,FGmin,FGmax,ABVmin,ABVmax,IBUmin,IBUmax,EBCmin,EBCmax")] Styl styl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(styl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(styl);
        }

        // GET: Styl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Styl styl = db.Style.Find(id);
            if (styl == null)
            {
                return HttpNotFound();
            }
            return View(styl);
        }

        // POST: Styl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Styl styl = db.Style.Find(id);
            db.Style.Remove(styl);
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
