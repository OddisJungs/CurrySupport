namespace CurrySupport.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<CurrySupport.DataModel.CurrySupportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CurrySupport.DataModel.CurrySupportContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.AlleStatusse.AddOrUpdate(x => x.Id,
                new Status() { Id = 1, Bezeichnung = "Bereit", Beschreibung = "Alles Bereit" });

            context.AlleKategorien.AddOrUpdate(x => x.Id,
                new Kategorie() { Id = 1, Bezeichnung = "System Fehler", Aktiv = true });

            context.AlleUnterkategorien.AddOrUpdate(x => x.Id,
                new Unterkategorie() { Id = 1, Bezeichnung = "Hardware Fehler", Aktiv = true, Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1) });

            context.AlleRollen.AddOrUpdate(x => x.Id,
                new Rolle() { Id = 1, Bezeichnung = "Administrator" });

            context.AllePersonen.AddOrUpdate(x => x.Id,
                new Person() { Id = 1, Name = "B�rgisser", Vorname = "Reto", Telefonnummer = "0417505234", Adresse = "Eggstrasse 2", Aktiv = true, Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 1) });

            context.AlleTickets.AddOrUpdate(x => x.Id,
                new Ticket() { Id = 1, Beschreibung = "Dieses Programm fertig schreiben", Priorit�t = 100, Aenderungsdatum=DateTime.Now, Erstellungsdatum=DateTime.Now, Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1), Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 1), Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 1), Personen= new ObservableCollection<Person>(context.AllePersonen.Where(x => x.Id == 1).ToList()) });
        }
    }
}