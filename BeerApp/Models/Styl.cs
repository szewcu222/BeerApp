using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Styl")]
    public partial class Styl
    {
        [Key]
        public int StylID { get; set; }

        [Required]
        public string NazwaStylu { get; set; }

        [Required]
        public string Kod { get; set; }

        public float OGmin { get; set; }
        public float OGmax { get; set; }
        public float FGmin { get; set; }
        public float FGmax { get; set; }
        public float ABVmin { get; set; }
        public float ABVmax { get; set; }
        public float IBUmin { get; set; }
        public float IBUmax { get; set; }
        public float EBCmin { get; set; }
        public float EBCmax { get; set; }


        public virtual ICollection<Receptura> Receptury { get; set; }
    }
}