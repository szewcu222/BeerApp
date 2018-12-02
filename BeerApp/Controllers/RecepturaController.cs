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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerApp.Controllers
{
    public class RecepturaController : Controller
    {
        private BeerContext db { get; set; }

        protected UserManager<Uzytkownik> userManager { get; set; }


        public RecepturaController()
        {
            db = new BeerContext();
            userManager = new UserManager<Uzytkownik>(new UserStore<Uzytkownik>(db));
        }

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
            return View(PopulateSelectList());
        }

        // POST: Receptura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RecepturaID,NazwaReceptury")] Receptura receptura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Receptury.Add(receptura);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(receptura);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecepturaViewModel recepturaView)
        {
            Receptura receptura = CompleteRecepturaInfo(recepturaView);

            db.Receptury.Add(receptura);
            db.SaveChanges();

            return RedirectToAction("Index");
            return View(recepturaView);
        }





        // GET: Receptura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecepturaViewModel recepturaView = PopulateSelectList();
            Receptura receptura = db.Receptury.Find(id);
            recepturaView.Receptura = receptura;

            if (receptura == null)
            {
                return HttpNotFound();
            }
            return View(recepturaView);
        }

        // POST: Receptura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecepturaViewModel recepturaView)
        {
            Receptura receptura = CompleteRecepturaInfo(recepturaView);

            db.Entry(receptura).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

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

        public ActionResult Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString) && searchString != "Wyszukaj fraze")
            {
                ViewBag.Odpowiedz = $"Receptury z frazą '{searchString}'";
                IQueryable<Receptura> receptury = db.Receptury.Where(s => s.NazwaReceptury.Contains(searchString)).Take(10);
                return View("Index", receptury);

            }
            return RedirectToAction("Index");
            
        }

        public ActionResult Moje()
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            IQueryable<Receptura> listaPrzepisowUzytkownika = db.Receptury.Where(m => m.Uzytkownik.Id == user.Id);

            if (listaPrzepisowUzytkownika.Count() > 0)
                return View(listaPrzepisowUzytkownika);
            else
                return View();
        }


        ///HELPERS
        private RecepturaViewModel PopulateSelectList()
        {
            RecepturaViewModel recepturaViewModel = new RecepturaViewModel();
            List<SelectListItem> listSelectListStyl = new List<SelectListItem>();

            foreach (Styl styl in db.Style)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = styl.NazwaStylu,
                    Value = styl.StylID.ToString()
                };
                listSelectListStyl.Add(selectListItem);
            }
            recepturaViewModel.ListaStylow = listSelectListStyl;

            List<SelectListItem> listSelectListChmiel = new List<SelectListItem>();
            foreach (Chmiel chmiel in db.Chmiele)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = chmiel.NazwaChmielu,
                    Value = chmiel.ChmielID.ToString()
                };
                listSelectListChmiel.Add(selectListItem);
            }
            recepturaViewModel.ListaChmieli = listSelectListChmiel;

            List<SelectListItem> listSelectListDrozdze = new List<SelectListItem>();
            foreach (Drozdze drozdze in db.Drozdze)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = drozdze.NazwaDrozdzy,
                    Value = drozdze.DrozdzeID.ToString()
                };
                listSelectListDrozdze.Add(selectListItem);
            }
            recepturaViewModel.ListaDrozdzy = listSelectListDrozdze;

            List<SelectListItem> listSelectListSlod = new List<SelectListItem>();
            foreach (Slod slod in db.Slody)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = slod.NazwaSlodu,
                    Value = slod.SlodID.ToString()
                };
                listSelectListSlod.Add(selectListItem);
            }
            recepturaViewModel.ListaSlodow = listSelectListSlod;

            List<SelectListItem> listSelectListPrzerwa = new List<SelectListItem>();
            foreach (Przerwa przerwa in db.Przerwy)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = przerwa.Etap,
                    Value = przerwa.PrzerwaID.ToString()
                };
                listSelectListPrzerwa.Add(selectListItem);
            }
            recepturaViewModel.ListaPrzerw = listSelectListPrzerwa;


            return recepturaViewModel;

        }


        private Receptura CompleteRecepturaInfo(RecepturaViewModel recepturaView)
        {

            Receptura receptura = recepturaView.Receptura;

            var user = userManager.FindById(User.Identity.GetUserId());

            Styl styl = db.Style.FirstOrDefault(s => s.StylID == recepturaView.Styl.StylID);
            receptura.Styl = styl;

            Drozdze drozdze = db.Drozdze.FirstOrDefault(d => d.DrozdzeID == recepturaView.Drozdze.DrozdzeID);
            receptura.Drozdze = drozdze;

            Slod slod = db.Slody.FirstOrDefault(s => s.SlodID == recepturaView.Slod.SlodID);
            SkladnikSlodu skladnikSlodu = new SkladnikSlodu() { Slod = slod, Ilosc = recepturaView.IloscSlodu };
            List<SkladnikSlodu> skladnikiSlodu = new List<SkladnikSlodu>();
            skladnikiSlodu.Add(skladnikSlodu);
            receptura.SkladnikiSlodu = skladnikiSlodu;

            Chmiel chmiel = db.Chmiele.FirstOrDefault(c => c.ChmielID == recepturaView.Chmiel.ChmielID);
            //SkladnikChmielu chmielReceptury = receptura.SkladnikiChmielu.FirstOrDefault(c => c.ChmielID == chmiel.ChmielID);
            //if(chmielReceptury==null)
            //{
                SkladnikChmielu skladnikChmielu = new SkladnikChmielu() { Chmiel = chmiel, Ilosc = recepturaView.IloscChmielu };
                List<SkladnikChmielu> skladnikiChmielu = new List<SkladnikChmielu>();
                skladnikiChmielu.Add(skladnikChmielu);
                receptura.SkladnikiChmielu = skladnikiChmielu;
            //}



            Przerwa przerwa = db.Przerwy.FirstOrDefault(p => p.PrzerwaID == recepturaView.Przerwa.PrzerwaID);
            List<Przerwa> przerwy = new List<Przerwa>();
            przerwy.Add(przerwa);
            receptura.Przerwy = przerwy;

            receptura.Uzytkownik = user;

            return receptura;
        }

    }
}
