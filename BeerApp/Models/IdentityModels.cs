﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Uzytkownik : IdentityUser
    {

        public Uzytkownik()
        {
            OstatniaAktywnosc = DateTime.Now;
        }

        public int PunktyWRankingu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime OstatniaAktywnosc { get; set; }
        public DateTime? DataRejestracji { get; set; }

        public virtual ICollection<Receptura> Receptury { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}