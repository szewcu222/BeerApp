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
        //public Receptura()
        //{
        //    IloscWody = IloscSlodu * StosunekWodaSlod;
        //}

        [Key]
        public int RecepturaID { get; set; }

        [Required]
        [Display(Name = "Nazwa receptury")]
        public string NazwaReceptury { get; set; }
        public string Opis { get; set; }


        public int TemperaturaFermentacji { get; set; }

        public float StosunekWodaSlod { get; set; } //Stosunek objętości wody do wagi słodu na początku zacierania 

        public float Wysladzanie { get; set; }      //Objętość wody użytej do wysładzania

        public float Gotowanie { get; set; }        //Objętość brzeczki przed gotowaniem

        public float Objetosc { get; set; }         //Objętość brzeczki przed zadaniem drożdży

        public float OG { get; set; }               //Ekstrakt przed zadaniem drożdży

        public float FG { get; set; }               //Ekstrakt po fermentacji

        public float ABV { get; set; }              //Zawartość alkoholu

        public float IBU { get; set; }              //Goryczka

        public float EBC { get; set; }              //Barwa

        public float IloscSlodu { get; set; }       //Czy potrzebne?
        public float IloscWody {get; set;}

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual Drozdze Drozdze { get; set; }
        public virtual Styl Styl { get; set; }

        public virtual ICollection<SkladnikSlodu> SkladnikiSlodu { get; set; }
        public virtual ICollection<SkladnikChmielu> SkladnikiChmielu { get; set; }
        public virtual ICollection<Przerwa> Przerwy { get; set; }

    }
}