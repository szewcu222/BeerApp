namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTolerancja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drozdze", "NazwaDrozdzy", c => c.String(nullable: false));
            AddColumn("dbo.Drozdze", "Tolerancja", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Chmiel", "AlfaKwasy", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "StosunekWodaSlod", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "Wysladzanie", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "Gotowanie", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "Objetosc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "OG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "FG", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "ABV", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "IBU", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "EBC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "IloscSlodu", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Receptura", "IloscWody", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Drozdze", "Odfermentowanie", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SkladnikSlodu", "Ilosc", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "OGmin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "OGmax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "FGmin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "FGmax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "ABVmin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "ABVmax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "IBUmin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "IBUmax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "EBCmin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Styl", "EBCmax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Drozdze", "Toleranjca");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drozdze", "Toleranjca", c => c.Int(nullable: false));
            AlterColumn("dbo.Styl", "EBCmax", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "EBCmin", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "IBUmax", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "IBUmin", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "ABVmax", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "ABVmin", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "FGmax", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "FGmin", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "OGmax", c => c.Single(nullable: false));
            AlterColumn("dbo.Styl", "OGmin", c => c.Single(nullable: false));
            AlterColumn("dbo.SkladnikSlodu", "Ilosc", c => c.Single(nullable: false));
            AlterColumn("dbo.Drozdze", "Odfermentowanie", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "IloscWody", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "IloscSlodu", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "EBC", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "IBU", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "ABV", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "FG", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "OG", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "Objetosc", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "Gotowanie", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "Wysladzanie", c => c.Single(nullable: false));
            AlterColumn("dbo.Receptura", "StosunekWodaSlod", c => c.Single(nullable: false));
            AlterColumn("dbo.Chmiel", "AlfaKwasy", c => c.Single(nullable: false));
            DropColumn("dbo.Drozdze", "Tolerancja");
            DropColumn("dbo.Drozdze", "NazwaDrozdzy");
        }
    }
}
