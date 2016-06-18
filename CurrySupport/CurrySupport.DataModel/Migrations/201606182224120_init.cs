namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        Rolle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rolles", t => t.Rolle_Id)
                .Index(t => t.Rolle_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beschreibung = c.String(nullable: false),
                        Lösung = c.String(),
                        Priorität = c.Int(nullable: false),
                        Erstellungsdatum = c.DateTime(),
                        Aenderungsdatum = c.DateTime(),
                        Kategorie_Id = c.Int(nullable: false),
                        Kunde_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        Unterkategorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategories", t => t.Kategorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Kunde_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.Unterkategories", t => t.Unterkategorie_Id)
                .Index(t => t.Kategorie_Id)
                .Index(t => t.Kunde_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Unterkategorie_Id);
            
            CreateTable(
                "dbo.TicketBearbeiterHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zuweisungsdatum = c.DateTime(nullable: false),
                        Person_Id = c.Int(nullable: false),
                        Ticket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Ticket_Id);
            
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
                "dbo.Rolles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Rolle_Id", "dbo.Rolles");
            DropForeignKey("dbo.Tickets", "Unterkategorie_Id", "dbo.Unterkategories");
            DropForeignKey("dbo.Tickets", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Tickets", "Kunde_Id", "dbo.People");
            DropForeignKey("dbo.Tickets", "Kategorie_Id", "dbo.Kategories");
            DropForeignKey("dbo.TicketBearbeiterHistories", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.TicketBearbeiterHistories", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Unterkategories", "Kategorie_Id", "dbo.Kategories");
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Ticket_Id" });
            DropIndex("dbo.TicketBearbeiterHistories", new[] { "Person_Id" });
            DropIndex("dbo.Tickets", new[] { "Unterkategorie_Id" });
            DropIndex("dbo.Tickets", new[] { "Status_Id" });
            DropIndex("dbo.Tickets", new[] { "Kunde_Id" });
            DropIndex("dbo.Tickets", new[] { "Kategorie_Id" });
            DropIndex("dbo.People", new[] { "Rolle_Id" });
            DropIndex("dbo.Unterkategories", new[] { "Kategorie_Id" });
            DropTable("dbo.Rolles");
            DropTable("dbo.Status");
            DropTable("dbo.TicketBearbeiterHistories");
            DropTable("dbo.Tickets");
            DropTable("dbo.People");
            DropTable("dbo.Unterkategories");
            DropTable("dbo.Kategories");
        }
    }
}
