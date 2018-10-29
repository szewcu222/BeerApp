using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Chmiel")]
    public partial class Chmiel
    {
        [Key]
        public int ChmielID { get; set; }

        [Required]
        public string NazwaChmielu { get; set; }

        public float AlfaKwasy { get; set; }

        public virtual ICollection<SkladnikChmielu> SkladnikiChmielu { get; set; }

    }
}