using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Slod")]
    public partial class Slod
    {
        [Key]
        public int SlodID { get; set; }
        
        [Required]
        public string NazwaSlodu { get; set; }

        public int Barwa { get; set; }


        public virtual ICollection<SkladnikSlodu> SkladnikiSlodu { get; set; }

    }
}