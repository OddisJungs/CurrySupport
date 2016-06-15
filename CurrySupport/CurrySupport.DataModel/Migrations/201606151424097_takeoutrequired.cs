namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class takeoutrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles");
            DropIndex("dbo.People", new[] { "Rolle_Id" });
            AlterColumn("dbo.People", "Rolle_Id", c => c.Int());
            CreateIndex("dbo.People", "Rolle_Id");
            AddForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles");
            DropIndex("dbo.People", new[] { "Rolle_Id" });
            AlterColumn("dbo.People", "Rolle_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "Rolle_Id");
            AddForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles", "Id", cascadeDelete: true);
        }
    }
}
