using BeerApp.DAL;
using BeerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerApp.Controllers
{
    public class HomeController : Controller
    {
        BeerContext db = new BeerContext();
        public ActionResult Index()
        {
            var chmiel = new Chmiel { AlfaKwasy = 4.12f, NazwaChmielu = "Marynka"};
            db.Chmiele.Add(chmiel);

            db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}