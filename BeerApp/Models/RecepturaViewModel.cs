using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerApp.Models
{
    public class RecepturaViewModel
    {

        public Receptura Receptura { get; set; }
        public Styl Styl { get; set; }
        public Przerwa Przerwa { get; set; }
        public Chmiel Chmiel { get; set; }
        public int IloscChmielu { get; set; }
        public Slod Slod { get; set; }
        public int IloscSlodu { get; set; }
        public Drozdze Drozdze { get; set; }


        public IEnumerable<SelectListItem> ListaStylow { get; set; }
        public IEnumerable<SelectListItem> ListaPrzerw { get; set; }
        public IEnumerable<SelectListItem> ListaChmieli { get; set; }
        public IEnumerable<SelectListItem> ListaSlodow { get; set; }
        public IEnumerable<SelectListItem> ListaDrozdzy { get; set; }


    }
}