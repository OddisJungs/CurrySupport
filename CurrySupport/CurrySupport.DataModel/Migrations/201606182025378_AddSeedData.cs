namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Ticket_Id" });
            AlterColumn("dbo.TicketBearbeiterHistories", "Ticket_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TicketBearbeiterHistories", "Ticket_Id");
            AddForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Ticket_Id" });
            AlterColumn("dbo.TicketBearbeiterHistories", "Ticket_Id", c => c.Int());
            CreateIndex("dbo.TicketBearbeiterHistories", "Ticket_Id");
            AddForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets", "Id");
        }
    }
}
