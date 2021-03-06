﻿using BeerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BeerApp.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var chmiel = new Chmiel { AlfaKwasy = 4.0M, NazwaChmielu = "INITIAL_DB" };
            context.Chmiele.Add(chmiel);

            var UserManager = new UserManager<Uzytkownik>(new UserStore<Uzytkownik>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE ROLI 'ADMIN' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            string roleNameAdmin = "Admin";

            if (!RoleManager.RoleExists(roleNameAdmin))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleNameAdmin));
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE ROLI 'MOD' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            string roleNameMod = "Mod";

            if (!RoleManager.RoleExists(roleNameMod))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleNameMod));
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE ROLI 'USER' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            string roleNameUser = "User";

            if (!RoleManager.RoleExists(roleNameUser))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleNameUser));
            }


            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE UŻYTKOWNIKÓW 'ADMIN' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            var user = new Uzytkownik() { UserName = "admin@przepisy.pl", Email = "admin@przepisy.pl", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now };

            if (UserManager.Create(user, "P@ssw0rd").Succeeded)
            {
                UserManager.AddToRole(user.Id, roleNameAdmin);
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE UŻYTKOWNIKÓW 'MOD' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            user = new Uzytkownik() { UserName = "mod@przepisy.pl", Email = "szewcu222@gmail.com", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now };

            if (UserManager.Create(user, "P@ssw0rd").Succeeded)
            {
                UserManager.AddToRole(user.Id, roleNameMod);
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE UŻYTKOWNIKÓW 'USER' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            List<Uzytkownik> listaUserow = new List<Uzytkownik>() {
                new Uzytkownik() { UserName = "4sobek4@gmail.com", Email = "4sobek4@gmail.com", Imie = "Sebastian", Nazwisko = "Szczepanski", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now },
                new Uzytkownik() { UserName = "laroja_ns9@gmail.com", Email = "laroja_ns9@gmail.com", Imie = "Tomek", Nazwisko = "Miss", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now },
                new Uzytkownik() { UserName = "cwel@gmail.com", Email = "cwel@gmail.com", Imie = "Lukasz", Nazwisko = "Gej", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now },
                new Uzytkownik() { UserName = "didajdisapojntciu@gmail.com", Email = "didajdisapojntciu@gmail.com", Imie = "James", Nazwisko = "Blunt", DataRejestracji = DateTime.Now, OstatniaAktywnosc = DateTime.Now }
            };

            foreach (var us in listaUserow)
            {
                if (UserManager.Create(us, "P@ssw0rd").Succeeded)
                {
                    UserManager.AddToRole(us.Id, roleNameUser);
                }
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STWORZENIE UŻYTKOWNIKÓW 'RECEPTURA' - - - - - - - - - - - - - - - - - - - - - - - 

            Slod slod1 = new Slod { NazwaSlodu = "PaleAle", Barwa = 12, Ekstraktywnosc = 80 };
            Slod slod2 = new Slod { NazwaSlodu = "Pilznenski", Barwa = 4, Ekstraktywnosc = 60 };

            Chmiel chmiel1 = new Chmiel { NazwaChmielu = "IUNGA", AlfaKwasy = 12.0M };
            Chmiel chmiel2 = new Chmiel { NazwaChmielu = "Lubelski", AlfaKwasy = 3.0M };



            Styl styl = new Styl { NazwaStylu = "APA", Kod = "APE123", OGmin= 12.0M, OGmax= 20.0M};

            Przerwa przerwa1 = new Przerwa { Etap = "Maltozowa", Temperatura = 66, CzasTrwania = 60 };
            Przerwa przerwa2 = new Przerwa { Etap = "Wygrzew", Temperatura = 75, CzasTrwania = 5 };

            Receptura receptura = new Receptura {
                NazwaReceptury = "RReceptura pyzianowska",
                Opis = "Receptura piwa warzonego pyzianowskiego",
                Drozdze = new Drozdze { NazwaDrozdzy = "asdf",Fermentacja = EFermentacja.dolna, Flokulacja = EFlokulacja.niska },
                Objetosc = 23.0M,
                Gotowanie = 30.0M,
                Wysladzanie = 10.0M,
                TemperaturaFermentacji = 18,
                SkladnikiSlodu = new List<SkladnikSlodu>
                {
                    new SkladnikSlodu {Ilosc=2, Slod=slod1},
                    new SkladnikSlodu {Ilosc=3, Slod=slod2}
                },
                IloscSlodu = 5.0M,
                SkladnikiChmielu = new List<SkladnikChmielu>
                {
                    new SkladnikChmielu {Ilosc=1, Chmiel=chmiel1},
                    new SkladnikChmielu {Ilosc=1, Chmiel=chmiel2},
                },
                Uzytkownik = context.Users.SingleOrDefault(u => u.UserName == "4sobek4@gmail.com"),
                Styl = styl,
                Przerwy = new List<Przerwa>
                {
                    przerwa1,
                    przerwa2
                },
                OG = 12.0M,
                FG = 2.0M,
                ABV = 5.0M,
                EBC = 20.0M,
                IBU = 30.0M
            };

            //Chmiel cmielStary = context.Chmiele.FirstOrDefault(c => c.NazwaChmielu == "submit"); ID 1, recID 00
            //Chmiel chmielNowy = new Chmiel
            //{
            //    NazwaChmielu = cmielStary.NazwaChmielu,
            //    SkladnikiChmielu = cmielStary.SkladnikiChmielu,
            //    AlfaKwasy = cmielStary.AlfaKwasy
            //};


            context.Receptury.Add(receptura);

            context.SaveChanges();
        }
    }
}