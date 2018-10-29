using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeerApp.Models
{
    [Table("Drozdze")]
    public partial class Drozdze
    {
        [Key]
        public int DrozdzeID { get; set; }

        [Required] string NazwaDrozdzy { get; set; }

        public EFlokulacja Flokulacja { get; set; } //Powinna być kategoria: niska, średnia, wysoka itp.

        
        public ICollection<Receptura> Receptury { get; set; }
    }

    public enum EFlokulacja
    {
        niska,
        srednia,
        wysoka
    }

}