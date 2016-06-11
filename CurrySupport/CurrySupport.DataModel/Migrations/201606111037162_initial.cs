namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                        Aktiv = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Unterkategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                        Aktiv = c.Boolean(nullable: false),
                        Kategorie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategories", t => t.Kategorie_Id, cascadeDelete: true)
                .Index(t => t.Kategorie_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Vorname = c.String(nullable: false),
                        Telefonnummer = c.String(nullable: false),
                        Adresse = c.String(nullable: false),
                        Aktiv = c.Boolean(nullable: false),
                        Rolle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rolles", t => t.Rolle_Id, cascadeDelete: true)
                .Index(t => t.Rolle_Id);
            
            CreateTable(
                "dbo.Rolles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beschreibung = c.String(nullable: false),
                        Priorität = c.Int(nullable: false),
                        Erstellungsdatum = c.DateTime(),
                        Aenderungsdatum = c.DateTime(),
                        Kategorie_Id = c.Int(nullable: false),
                        Status_Id = c.Int(),
                        Unterkategorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategories", t => t.Kategorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.Unterkategories", t => t.Unterkategorie_Id)
                .Index(t => t.Kategorie_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Unterkategorie_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketPersons",
                c => new
                    {
                        Ticket_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_Id, t.Person_Id })
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Ticket_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Unterkategorie_Id", "dbo.Unterkategories");
            DropForeignKey("dbo.Tickets", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.TicketPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.TicketPersons", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Kategorie_Id", "dbo.Kategories");
            DropForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles");
            DropForeignKey("dbo.Unterkategories", "Kategorie_Id", "dbo.Kategories");
            DropIndex("dbo.TicketPersons", new[] { "Person_Id" });
            DropIndex("dbo.TicketPersons", new[] { "Ticket_Id" });
            DropIndex("dbo.Tickets", new[] { "Unterkategorie_Id" });
            DropIndex("dbo.Tickets", new[] { "Status_Id" });
            DropIndex("dbo.Tickets", new[] { "Kategorie_Id" });
            DropIndex("dbo.People", new[] { "Rolle_Id" });
            DropIndex("dbo.Unterkategories", new[] { "Kategorie_Id" });
            DropTable("dbo.TicketPersons");
            DropTable("dbo.Status");
            DropTable("dbo.Tickets");
            DropTable("dbo.Rolles");
            DropTable("dbo.People");
            DropTable("dbo.Unterkategories");
            DropTable("dbo.Kategories");
        }
    }
}
