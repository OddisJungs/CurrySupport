using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //  context.People.AddOrUpdate(
            //    p => p.FullName,
            //    new Person { FullName = "Andrew Peters" },
            //    new Person { FullName = "Brice Lambson" },
            //    new Person { FullName = "Rowan Miller" }
            //  );


            try
            {

                context.AlleStatusse.AddOrUpdate(x => x.Id,
                    new Status()
                    {
                        Id = 1,
                        Bezeichnung = "Offen",
                        Beschreibung = "Ticket geöffnet"
                    },
                    new Status()
                    {
                        Id = 2,
                        Bezeichnung = "In Planung",
                        Beschreibung = "Ticket in Planung"
                    },
                    new Status()
                    {
                        Id = 3,
                        Bezeichnung = "In Arbeit",
                        Beschreibung = "Ticket in Arbeit"
                    },
                    new Status()
                    {
                        Id = 4,
                        Bezeichnung = "In Testing",
                        Beschreibung = "Ticket wird getestet"
                    },
                    new Status()
                    {
                        Id = 5,
                        Bezeichnung = "Fertig",
                        Beschreibung = "Ticket ist fertig"
                    }
                    );
                context.SaveChanges();
                context.AlleKategorien.AddOrUpdate(x => x.Id,
                    new Kategorie()
                    {
                        Id = 1,
                        Bezeichnung = "Software",
                        Aktiv = true
                    },
                    new Kategorie()
                    {
                        Id = 2,
                        Bezeichnung = "Hardware",
                        Aktiv = true
                    },
                    new Kategorie()
                    {
                        Id = 3,
                        Bezeichnung = "Service",
                        Aktiv = true
                    },
                    new Kategorie()
                    {
                        Id = 4,
                        Bezeichnung = "Reklamation",
                        Aktiv = true
                    }
                    );
                context.SaveChanges();
                context.AlleUnterkategorien.AddOrUpdate(x => x.Id,
                    new Unterkategorie()
                    {
                        Id = 1,
                        Bezeichnung = "Betriebssystem",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 2,
                        Bezeichnung = "Individualsoftware",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 3,
                        Bezeichnung = "Standardsoftware",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 4,
                        Bezeichnung = "Dienstprogramme",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 5,
                        Bezeichnung = "Treiber",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 6,
                        Bezeichnung = "Weitere Softwareanfragen",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1)
                    },
                    new Unterkategorie()
                    {
                        Id = 7,
                        Bezeichnung = "Arbeitsplatz (Workstation)",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2)
                    },
                    new Unterkategorie()
                    {
                        Id = 8,
                        Bezeichnung = "Server",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2)
                    },
                    new Unterkategorie()
                    {
                        Id = 9,
                        Bezeichnung = "Peripheriegerät",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2)
                    },
                    new Unterkategorie()
                    {
                        Id = 10,
                        Bezeichnung = "Netzwerk",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2)
                    },
                    new Unterkategorie()
                    {
                        Id = 11,
                        Bezeichnung = "Weitere Hardwareanfragen",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2)
                    },
                    new Unterkategorie()
                    {
                        Id = 12,
                        Bezeichnung = "Zugriff",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3)
                    },
                    new Unterkategorie()
                    {
                        Id = 13,
                        Bezeichnung = "Betrieb",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3)
                    },
                    new Unterkategorie()
                    {
                        Id = 14,
                        Bezeichnung = "Dokumente",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3)
                    },
                    new Unterkategorie()
                    {
                        Id = 15,
                        Bezeichnung = "Antivirus/Firewall",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3)
                    },
                    new Unterkategorie()
                    {
                        Id = 16,
                        Bezeichnung = "Weitere Serviceanfragen",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3)
                    },
                    new Unterkategorie()
                    {
                        Id = 17,
                        Bezeichnung = "1st Level",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 4)
                    },
                    new Unterkategorie()
                    {
                        Id = 18,
                        Bezeichnung = "2nd Level",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 4)
                    },
                    new Unterkategorie()
                    {
                        Id = 19,
                        Bezeichnung = "3rd Level",
                        Aktiv = true,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 4)
                    }
                    );
                context.SaveChanges();
                context.AlleRollen.AddOrUpdate(x => x.Id,
                    new Rolle()
                    {
                        Id = 1,
                        Bezeichnung = "Bearbeiter"
                    });
                context.SaveChanges();
                context.AlleRollen.AddOrUpdate(x => x.Id,
                    new Rolle()
                    {
                        Id = 2,
                        Bezeichnung = "Kunde"
                    });
                context.SaveChanges();
                context.AllePersonen.AddOrUpdate(x => x.Id,
                    new Person()
                    {
                        Id = 1,
                        Name = "Muster",
                        Vorname = "Max",
                        Telefonnummer = "044 000 00 00",
                        Adresse = "Musterstrasse 1",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 2)
                    },
                    new Person()
                    {
                        Id = 2,
                        Name = "Beispiel",
                        Vorname = "Hans",
                        Telefonnummer = "041 001 01 01",
                        Adresse = "Beispielstrasse 1",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 2)
                    },
                    new Person()
                    {
                        Id = 3,
                        Name = "Iuvenis",
                        Vorname = "Manuuuuuel",
                        Telefonnummer = "012 345 67 89",
                        Adresse = "Iuvenisstrasse 7",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 2)
                    },
                    new Person()
                    {
                        Id = 4,
                        Name = "Bürgisser",
                        Vorname = "Reto",
                        Telefonnummer = "041 750 52 34",
                        Adresse = "Eggstrasse 2",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 1)
                    },
                    new Person()
                    {
                        Id = 5,
                        Name = "Schnider",
                        Vorname = "Cédric",
                        Telefonnummer = "041 787 91 43",
                        Adresse = "Hinterwäldlerstrasse 69",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 1)
                    },
                    new Person()
                    {
                        Id = 6,
                        Name = "Metzger",
                        Vorname = "Roger",
                        Telefonnummer = "077 490 32 31",
                        Adresse = "Im Hobacher 9",
                        Aktiv = true,
                        Rolle = context.AlleRollen.FirstOrDefault(x => x.Id == 1)
                    }
                    );

                context.SaveChanges();

                //context.AlleTickets.AddOrUpdate(x => x.Id,
                var tickets = new List<Ticket>
                {
                    new Ticket()
                    {
                        Id = 1,
                        Beschreibung = "Dieses Programm fertig schreiben",
                        Priorität = 1,
                        Lösung = "Schreiben, Schreiben, Schreiben ...",
                        Aenderungsdatum = DateTime.Now,
                        Erstellungsdatum = DateTime.Now,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1),
                        Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 3),
                        Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 1),
                        BearbeiterHistory = new ObservableCollection<TicketBearbeiterHistory>(context.AlleTicketBearbeiterHistoryEinträge.ToList()),
                        Kunde = context.AllePersonen.FirstOrDefault(x => x.Id == 3)
                    },
                    new Ticket()
                    {
                        Id = 2,
                        Beschreibung = "Testen",
                        Priorität = 2,
                        Lösung = "Ein KV-Lehrling anstellen",
                        Aenderungsdatum = DateTime.Now,
                        Erstellungsdatum = DateTime.Now,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 1),
                        Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 4),
                        Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 2),
                        BearbeiterHistory = new ObservableCollection<TicketBearbeiterHistory>(context.AlleTicketBearbeiterHistoryEinträge.ToList()),
                        Kunde = context.AllePersonen.FirstOrDefault(x => x.Id == 2)
                    },
                    new Ticket()
                    {
                        Id = 3,
                        Beschreibung = "PC aufsetzen",
                        Priorität = 3,
                        Lösung = "Materialien besorgen und aufsetzen",
                        Aenderungsdatum = DateTime.Now,
                        Erstellungsdatum = DateTime.Now,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 2),
                        Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 2),
                        Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 8),
                        BearbeiterHistory = new ObservableCollection<TicketBearbeiterHistory>(context.AlleTicketBearbeiterHistoryEinträge.ToList()),
                        Kunde = context.AllePersonen.FirstOrDefault(x => x.Id == 2)
                    },
                    new Ticket()
                    {
                        Id = 4,
                        Beschreibung = "iTunes deinstallieren",
                        Priorität = 3,
                        Lösung = "Programme und Features > iTunes > deinstallieren",
                        Aenderungsdatum = DateTime.Now,
                        Erstellungsdatum = DateTime.Now,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 3),
                        Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 5),
                        Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 15),
                        BearbeiterHistory = new ObservableCollection<TicketBearbeiterHistory>(context.AlleTicketBearbeiterHistoryEinträge.ToList()),
                        Kunde = context.AllePersonen.FirstOrDefault(x => x.Id == 1)
                    },
                    new Ticket()
                    {
                        Id = 5,
                        Beschreibung = "Office installieren",
                        Priorität = 1,
                        Lösung = "Lizenz besorgen und installieren",
                        Aenderungsdatum = DateTime.Now,
                        Erstellungsdatum = DateTime.Now,
                        Kategorie = context.AlleKategorien.FirstOrDefault(x => x.Id == 4),
                        Status = context.AlleStatusse.FirstOrDefault(x => x.Id == 1),
                        Unterkategorie = context.AlleUnterkategorien.FirstOrDefault(x => x.Id == 18),
                        BearbeiterHistory = new ObservableCollection<TicketBearbeiterHistory>(context.AlleTicketBearbeiterHistoryEinträge.ToList()),
                        Kunde = context.AllePersonen.FirstOrDefault(x => x.Id == 3)
                    }
                };
                tickets.ForEach(t => context.AlleTickets.Add(t));
                context.SaveChanges();

                //context.AlleTicketBearbeiterHistoryEinträge.AddOrUpdate(x => x.Id,
                var ticketbearbeiterHistories = new List<TicketBearbeiterHistory>
                {
                    new TicketBearbeiterHistory()
                    {
                        Id = 1,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 4),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 1)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 2,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 5),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 1)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 3,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 6),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 2)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 4,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 6),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 3)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 5,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 4),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 4)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 6,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 6),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 5)
                    },
                    new TicketBearbeiterHistory()
                    {
                        Id = 7,
                        Person = context.AllePersonen.FirstOrDefault(x => x.Id == 5),
                        Zuweisungsdatum = DateTime.Now,
                        Ticket = tickets.FirstOrDefault(x => x.Id == 3)
                    }
                };
                ticketbearbeiterHistories.ForEach(tb => context.AlleTicketBearbeiterHistoryEinträge.AddOrUpdate(tb));
                context.SaveChanges();

                tickets[0].BearbeiterHistory.Add(ticketbearbeiterHistories[0]);
                tickets[0].BearbeiterHistory.Add(ticketbearbeiterHistories[1]);
                tickets[1].BearbeiterHistory.Add(ticketbearbeiterHistories[2]);
                tickets[2].BearbeiterHistory.Add(ticketbearbeiterHistories[3]);
                tickets[2].BearbeiterHistory.Add(ticketbearbeiterHistories[6]);
                tickets[3].BearbeiterHistory.Add(ticketbearbeiterHistories[4]);
                tickets[4].BearbeiterHistory.Add(ticketbearbeiterHistories[5]);

                tickets.ForEach(t => context.AlleTickets.AddOrUpdate(t));

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.Write(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.Write(string.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage));
                    }
                }
                throw;
            }
        }
    }
}
