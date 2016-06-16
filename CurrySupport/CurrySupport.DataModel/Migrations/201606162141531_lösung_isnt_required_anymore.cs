namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lösung_isnt_required_anymore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Lösung", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Lösung", c => c.String(nullable: false));
        }
    }
}
