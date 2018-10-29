using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("SklandikSlodu")]
    public partial class SkladnikSlodu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecepturaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlodID { get; set; }

        public decimal Ilosc { get; set; }


        public virtual Receptura Receptura { get; set; }

        public virtual Slod Slod { get; set; }

    }
}