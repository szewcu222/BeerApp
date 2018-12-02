namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BeerApp.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<BeerApp.DAL.BeerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BeerApp.DAL.BeerContext";
        }

        protected override void Seed(BeerApp.DAL.BeerContext context)
        {
            var pas = "";
            //UNCOMMENT THIS                !!!!!!!!!!!
            InitialDb.SeedBeer(context);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
