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
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }

        [Display(Name = "Temperatura fermentacji")]
        public int TemperaturaFermentacji { get; set; }

        [Display(Name = "Ilosc wody na kg slodu")]
        public decimal StosunekWodaSlod { get; set; } //Stosunek objętości wody do wagi słodu na początku zacierania 

        [Display(Name = "Objetosc wody do wysladzania")]
        public decimal Wysladzanie { get; set; }      //Objętość wody użytej do wysładzania

        [Display(Name = "Objetosc przed gotowaniem")]
        public decimal Gotowanie { get; set; }        //Objętość brzeczki przed gotowaniem

        [Display(Name = "Objetosc przed fermentacja")]
        public decimal Objetosc { get; set; }         //Objętość brzeczki przed zadaniem drożdży

        [Display(Name = "Ekstrakt poczatkowy")]
        public decimal OG { get; set; }               //Ekstrakt przed zadaniem drożdży

        [Display(Name = "Ekstrakt koncowy")]
        public decimal FG { get; set; }               //Ekstrakt po fermentacji

        [Display(Name = "Alk. obj.")]
        public decimal ABV { get; set; }              //Zawartość alkoholu

        [Display(Name = "Goryczka [IBU]")]
        public decimal IBU { get; set; }              //Goryczka

        [Display(Name = "Barwa [EBC]")]
        public decimal EBC { get; set; }              //Barwa

        public decimal IloscSlodu { get; set; }       //Czy potrzebne?
        public decimal IloscWody {get; set;}

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual Drozdze Drozdze { get; set; }
        public virtual Styl Styl { get; set; }

        public virtual ICollection<SkladnikSlodu> SkladnikiSlodu { get; set; }
        public virtual ICollection<SkladnikChmielu> SkladnikiChmielu { get; set; }
        public virtual ICollection<Przerwa> Przerwy { get; set; }

    }
}