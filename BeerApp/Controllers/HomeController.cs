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
        DAL.BeerContext db = new DAL.BeerContext();
        public ActionResult Index()
        {
            IQueryable<Receptura> receptury = db.Receptury.Take(10);


            return View();
        }

        public JsonResult RecepturaTest()
        {
            var receptura = db.Receptury.FirstOrDefault();
            var json = Json(receptura);

            return json;
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