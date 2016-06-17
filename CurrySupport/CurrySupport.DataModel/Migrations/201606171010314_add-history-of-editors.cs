namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhistoryofeditors : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tickets", new[] { "Bearbeiter_Id" });
            RenameColumn(table: "dbo.Tickets", name: "Bearbeiter_Id", newName: "Person_Id");
            CreateTable(
                "dbo.TicketBearbeiterHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zuweisungsdatum = c.DateTime(nullable: false),
                        Person_Id = c.Int(nullable: false),
                        Ticket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Ticket_Id);
            
            AlterColumn("dbo.Tickets", "Person_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Person_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.TicketBearbeiterHistories", "Person_Id", "dbo.People");
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Ticket_Id" });
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Person_Id" });
            DropIndex("dbo.Tickets", new[] { "Person_Id" });
            AlterColumn("dbo.Tickets", "Person_Id", c => c.Int(nullable: false));
            DropTable("dbo.TicketBearbeiterHistories");
            RenameColumn(table: "dbo.Tickets", name: "Person_Id", newName: "Bearbeiter_Id");
            CreateIndex("dbo.Tickets", "Bearbeiter_Id");
        }
    }
}
