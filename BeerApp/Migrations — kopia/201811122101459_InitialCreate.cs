namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chmiel",
                c => new
                    {
                        ChmielID = c.Int(nullable: false, identity: true),
                        NazwaChmielu = c.String(nullable: false),
                        AlfaKwasy = c.Single(nullable: false),
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
                        Drozdze_DrozdzeID = c.Int(),
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
                        Flokulacja = c.Int(nullable: false),
                        Fermentacja = c.Int(nullable: false),
                        Tolerancja = c.Int(nullable: false),
                        Odfermentowanie = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DrozdzeID);
            
            CreateTable(
                "dbo.SklandikSlodu",
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
                        OGmin = c.Single(nullable: false),
                        OGmax = c.Single(nullable: false),
                        FGmin = c.Single(nullable: false),
                        FGmax = c.Single(nullable: false),
                        ABVmin = c.Single(nullable: false),
                        ABVmax = c.Single(nullable: false),
                        IBUmin = c.Single(nullable: false),
                        IBUmax = c.Single(nullable: false),
                        EBCmin = c.Single(nullable: false),
                        EBCmax = c.Single(nullable: false),
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
            DropForeignKey("dbo.SklandikSlodu", "SlodID", "dbo.Slod");
            DropForeignKey("dbo.SklandikSlodu", "RecepturaID", "dbo.Receptura");
            DropForeignKey("dbo.SkladnikChmielu", "RecepturaID", "dbo.Receptura");
            DropForeignKey("dbo.Receptura", "Drozdze_DrozdzeID", "dbo.Drozdze");
            DropForeignKey("dbo.SkladnikChmielu", "ChmielID", "dbo.Chmiel");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SklandikSlodu", new[] { "SlodID" });
            DropIndex("dbo.SklandikSlodu", new[] { "RecepturaID" });
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
            DropTable("dbo.SklandikSlodu");
            DropTable("dbo.Drozdze");
            DropTable("dbo.Receptura");
            DropTable("dbo.SkladnikChmielu");
            DropTable("dbo.Chmiel");
        }
    }
}
