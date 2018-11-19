namespace BeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkladnikSloduRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SklandikSlodu", newName: "SkladnikSlodu");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SkladnikSlodu", newName: "SklandikSlodu");
        }
    }
}
