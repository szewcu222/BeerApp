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


        public virtual ICollection<Receptura> Receptury { get; set; }
    }
}