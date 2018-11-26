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
        [Display(Name = "Nazwa stylu")]
        public string NazwaStylu { get; set; }

        [Required]
        public string Kod { get; set; }

        [Display(Name = "OG min")]
        public decimal OGmin { get; set; }

        [Display(Name = "OG max")]
        public decimal OGmax { get; set; }

        [Display(Name = "FG min")]
        public decimal FGmin { get; set; }

        [Display(Name = "FG max")]
        public decimal FGmax { get; set; }

        [Display(Name = "Alk. min")]
        public decimal ABVmin { get; set; }

        [Display(Name = "Alk. max")]
        public decimal ABVmax { get; set; }

        [Display(Name = "IBU min")]
        public decimal IBUmin { get; set; }

        [Display(Name = "IBU max")]
        public decimal IBUmax { get; set; }

        [Display(Name = "EBC min")]
        public decimal EBCmin { get; set; }

        [Display(Name = "EBC max")]
        public decimal EBCmax { get; set; }


        public virtual ICollection<Receptura> Receptury { get; set; }
    }
}