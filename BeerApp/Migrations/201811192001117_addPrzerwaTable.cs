namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrzerwaTable : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Receptura", "StosunekWodaSlod", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "Wysladzanie", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "Gotowanie", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "Objetosc", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "TemperaturaFermentacji", c => c.Int(nullable: false));
            AddColumn("dbo.Receptura", "OG", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "FG", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "ABV", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "IBU", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "EBC", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "Opis", c => c.String());
            AlterColumn("dbo.SklandikSlodu", "Ilosc", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Przerwa", "Receptura_RecepturaID", "dbo.Receptura");
            DropIndex("dbo.Przerwa", new[] { "Receptura_RecepturaID" });
            AlterColumn("dbo.SklandikSlodu", "Ilosc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Receptura", "Opis");
            DropColumn("dbo.Receptura", "EBC");
            DropColumn("dbo.Receptura", "IBU");
            DropColumn("dbo.Receptura", "ABV");
            DropColumn("dbo.Receptura", "FG");
            DropColumn("dbo.Receptura", "OG");
            DropColumn("dbo.Receptura", "TemperaturaFermentacji");
            DropColumn("dbo.Receptura", "Objetosc");
            DropColumn("dbo.Receptura", "Gotowanie");
            DropColumn("dbo.Receptura", "Wysladzanie");
            DropColumn("dbo.Receptura", "StosunekWodaSlod");
            DropTable("dbo.Przerwa");
        }
    }
}
