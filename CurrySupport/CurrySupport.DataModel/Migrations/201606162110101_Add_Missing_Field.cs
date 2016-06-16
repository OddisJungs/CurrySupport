namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Missing_Field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Lösung", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Lösung");
        }
    }
}
