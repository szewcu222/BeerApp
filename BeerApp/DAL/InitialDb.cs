using BeerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeerApp.DAL
{
    public class InitialDb : DropCreateDatabaseAlways<BeerContext>
    {
        protected override void Seed(BeerContext context)
        {
            SeedBeer(context);
            base.Seed(context);
        }

        private void SeedBeer(BeerContext context)
        {
            var chmiel = new Chmiel { AlfaKwasy = 4.12f, NazwaChmielu = "INITIAL_DB" };
            context.Chmiele.Add(chmiel);

            context.SaveChanges();
        }
    }
}