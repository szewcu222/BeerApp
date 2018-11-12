using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Receptura")]
    public class Receptura
    {

        [Key]
        public int RecepturaID { get; set; }

        [Required]
        [Display(Name = "Nazwa receptury")]
        public string NazwaReceptury { get; set; }



        public virtual Uzytkownik Uzytkownik {get; set; }

        public virtual Drozdze Drozdze { get; set; }

        public virtual Styl Styl { get; set; }


        public virtual ICollection<SkladnikSlodu> SkladnikiSlodu { get; set; }

        public virtual ICollection<SkladnikChmielu> SkladnikiChmielu { get; set; }
    }
}