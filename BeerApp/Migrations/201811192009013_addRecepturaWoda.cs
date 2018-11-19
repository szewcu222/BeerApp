namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRecepturaWoda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receptura", "IloscSlodu", c => c.Single(nullable: false));
            AddColumn("dbo.Receptura", "IloscWody", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receptura", "IloscWody");
            DropColumn("dbo.Receptura", "IloscSlodu");
        }
    }
}
