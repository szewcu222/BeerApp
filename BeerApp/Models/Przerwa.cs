using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Przerwa")]
    public class Przerwa
    {
        [Key]
        public int PrzerwaID { get; set; }

        [Required]
        [Display(Name = "Etap")]
        public string Etap { get; set; }
        public int Temperatura { get; set; }
        [Display(Name = "Czas trwania")]
        public int CzasTrwania { get; set; }


        public Receptura Receptura { get; set; }

    }
}