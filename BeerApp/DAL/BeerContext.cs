using BeerApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BeerApp.DAL
{
    public class BeerContext : IdentityDbContext<Uzytkownik>
    {
        public BeerContext() : base("BeerContext")
        {
        }

        static BeerContext()
        {
            Database.SetInitializer<BeerContext>(new InitialDb());
        }

        public DbSet<Receptura> Receptury { get; set; }
        public DbSet<Slod> Slody { get; set; }
        public DbSet<SkladnikSlodu> SkladnikiSlodu { get; set; }
        public DbSet<Chmiel> Chmiele { get; set; }
        public DbSet<SkladnikChmielu> SklandikiChmielu { get; set; }
        public DbSet<Styl> Style { get; set; }

        public static BeerContext Create()
        {
            return new BeerContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //using System.Data.Entity.ModelConfiguration.Conventionsl
            //Wyłącza konwencje, ktora automatycznie tworzy liczbe mnoga dla nazw tabel w bazie danych
            //Zamiast Kategorie mielibysmy Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<BeerApp.Models.Drozdze> Drozdzes { get; set; }
    }
}