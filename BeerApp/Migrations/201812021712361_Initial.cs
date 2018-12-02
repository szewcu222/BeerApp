namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chmiel",
                c => new
                    {
                        ChmielID = c.Int(nullable: false, identity: true),
                        NazwaChmielu = c.String(nullable: false),
                        AlfaKwasy = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ChmielID);
            
            CreateTable(
                "dbo.SkladnikChmielu",
                c => new
                    {
                        RecepturaID = c.Int(nullable: false),
                        ChmielID = c.Int(nullable: false),
                        Ilosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.RecepturaID, t.ChmielID })
                .ForeignKey("dbo.Chmiel", t => t.ChmielID, cascadeDelete: true)
                .ForeignKey("dbo.Receptura", t => t.RecepturaID, cascadeDelete: true)
                .Index(t => t.RecepturaID)
                .Index(t => t.ChmielID);
            
            CreateTable(
                "dbo.Receptura",
                c => new
                    {
                        RecepturaID = c.Int(nullable: false, identity: true),
                        NazwaReceptury = c.String(nullable: false),
                        Opis = c.String(),
                        TemperaturaFermentacji = c.Int(nullable: false),
                        StosunekWodaSlod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wysladzanie = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gotowanie = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Objetosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ABV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IBU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EBC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IloscSlodu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IloscWody = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Drozdze_DrozdzeID = c.Int(nullable:true),
                        Styl_StylID = c.Int(),
                        Uzytkownik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RecepturaID)
                .ForeignKey("dbo.Drozdze", t => t.Drozdze_DrozdzeID)
                .ForeignKey("dbo.Styl", t => t.Styl_StylID)
                .ForeignKey("dbo.AspNetUsers", t => t.Uzytkownik_Id)
                .Index(t => t.Drozdze_DrozdzeID)
                .Index(t => t.Styl_StylID)
                .Index(t => t.Uzytkownik_Id);
            
            CreateTable(
                "dbo.Drozdze",
                c => new
                    {
                        DrozdzeID = c.Int(nullable: false, identity: true),
                        NazwaDrozdzy = c.String(nullable: false),
                        Flokulacja = c.Int(nullable: false),
                        Fermentacja = c.Int(nullable: false),
                        Tolerancja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Odfermentowanie = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DrozdzeID);
            
            CreateTable(
                "dbo.Przerwa",
                c => new
                    {
                        PrzerwaID = c.Int(nullable: false, identity: true),
                        Etap = c.String(nullable: false),
                        Temperatura = c.Int(nullable: false),
                        CzasTrwania = c.Int(nullable: false),
                        Receptura_RecepturaID = c.Int(),
                    })
                .PrimaryKey(t => t.PrzerwaID)
                .ForeignKey("dbo.Receptura", t => t.Receptura_RecepturaID)
                .Index(t => t.Receptura_RecepturaID);
            
            CreateTable(
                "dbo.SkladnikSlodu",
                c => new
                    {
                        RecepturaID = c.Int(nullable: false),
                        SlodID = c.Int(nullable: false),
                        Ilosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.RecepturaID, t.SlodID })
                .ForeignKey("dbo.Receptura", t => t.RecepturaID, cascadeDelete: true)
                .ForeignKey("dbo.Slod", t => t.SlodID, cascadeDelete: true)
                .Index(t => t.RecepturaID)
                .Index(t => t.SlodID);
            
            CreateTable(
                "dbo.Slod",
                c => new
                    {
                        SlodID = c.Int(nullable: false, identity: true),
                        NazwaSlodu = c.String(nullable: false),
                        Barwa = c.Int(nullable: false),
                        Ekstraktywnosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlodID);
            
            CreateTable(
                "dbo.Styl",
                c => new
                    {
                        StylID = c.Int(nullable: false, identity: true),
                        NazwaStylu = c.String(nullable: false),
                        Kod = c.String(nullable: false),
                        OGmin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OGmax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FGmin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FGmax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ABVmin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ABVmax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IBUmin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IBUmax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EBCmin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EBCmax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StylID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PunktyWRankingu = c.Int(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        OstatniaAktywnosc = c.DateTime(nullable: false),
                        DataRejestracji = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Receptura", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Receptura", "Styl_StylID", "dbo.Styl");
            DropForeignKey("dbo.SkladnikSlodu", "SlodID", "dbo.Slod");
            DropForeignKey("dbo.SkladnikSlodu", "RecepturaID", "dbo.Receptura");
            DropForeignKey("dbo.SkladnikChmielu", "RecepturaID", "dbo.Receptura");
            DropForeignKey("dbo.Przerwa", "Receptura_RecepturaID", "dbo.Receptura");
            DropForeignKey("dbo.Receptura", "Drozdze_DrozdzeID", "dbo.Drozdze");
            DropForeignKey("dbo.SkladnikChmielu", "ChmielID", "dbo.Chmiel");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SkladnikSlodu", new[] { "SlodID" });
            DropIndex("dbo.SkladnikSlodu", new[] { "RecepturaID" });
            DropIndex("dbo.Przerwa", new[] { "Receptura_RecepturaID" });
            DropIndex("dbo.Receptura", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Receptura", new[] { "Styl_StylID" });
            DropIndex("dbo.Receptura", new[] { "Drozdze_DrozdzeID" });
            DropIndex("dbo.SkladnikChmielu", new[] { "ChmielID" });
            DropIndex("dbo.SkladnikChmielu", new[] { "RecepturaID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Styl");
            DropTable("dbo.Slod");
            DropTable("dbo.SkladnikSlodu");
            DropTable("dbo.Przerwa");
            DropTable("dbo.Drozdze");
            DropTable("dbo.Receptura");
            DropTable("dbo.SkladnikChmielu");
            DropTable("dbo.Chmiel");
        }
    }
}
