using BeerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BeerApp.Migrations;

namespace BeerApp.DAL
{
    public class InitialDb : MigrateDatabaseToLatestVersion<BeerContext, Configuration>
    {
        //protected override void Seed(BeerContext context)
        //{
        //    SeedBeer(context);
        //    base.Seed(context);
        //}

        public static void SeedBeer(BeerContext context)
        {
            var chmiel = new Chmiel { AlfaKwasy = 4.12f, NazwaChmielu = "INITIAL_DB" };
            context.Chmiele.Add(chmiel);

            context.SaveChanges();
        }
    }
}