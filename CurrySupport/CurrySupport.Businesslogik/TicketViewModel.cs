using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class TicketViewModel : BaseViewModel
    {
        public TicketViewModel()
        {
            dbContext = new CurrySupportContext();
            Ticket = new Ticket();
            Ticket.Erstellungsdatum = DateTime.Now;
            AktuellerBearbeiter = new Person();
            Construct();
        }

        public TicketViewModel(int ticketId)
        {
            dbContext = new CurrySupportContext();
            Ticket = dbContext.AlleTickets.Find(ticketId);
            AktuellerBearbeiter = Ticket.BearbeiterHistory.OrderByDescending(x => x.Zuweisungsdatum).FirstOrDefault().Person;
            Construct();
        }
        private void Construct()
        {
            BearbeiterListe = new ObservableCollection<Person>(dbContext.AllePersonen.Where(x => x.Rolle.Bezeichnung == "Bearbeiter").ToList());
            KundenListe = new ObservableCollection<Person>(dbContext.AllePersonen.Where(x => x.Rolle.Bezeichnung == "Kunde").ToList());
            Kategorien = new ObservableCollection<Kategorie>(dbContext.AlleKategorien.ToList());
            Unterkategorien = new ObservableCollection<Unterkategorie>(dbContext.AlleUnterkategorien.ToList());
            Statusse = new ObservableCollection<Status>(dbContext.AlleStatusse.ToList());
        }

        public bool SaveTicket()
        {
            Ticket.Aenderungsdatum = DateTime.Now;
            if (Ticket.Id == 0 ||AktuellerBearbeiter != Ticket.BearbeiterHistory.OrderByDescending(x => x.Zuweisungsdatum).FirstOrDefault().Person)
            {
                // Bearbeiter History um Ausgewählten Bearbeiter erweitern
                TicketBearbeiterHistory history = new TicketBearbeiterHistory();
                history.Person = AktuellerBearbeiter;
                history.Zuweisungsdatum = DateTime.Now;
                Ticket.BearbeiterHistory.Add(history);

                if (Ticket.Id == 0)
                {
                    // Wenn ticket noch nicht existiert, neues erstellen
                    dbContext.AlleTickets.Add(Ticket);
                }
            }
            dbContext.SaveChanges();
            return true;
        }

        public Ticket Ticket { get; set; }
        public Person AktuellerBearbeiter { get; set; }
        public ObservableCollection<Kategorie> Kategorien { get; set; }
        public ObservableCollection<Unterkategorie> Unterkategorien { get; set; }
        public ObservableCollection<Person> BearbeiterListe { get; set; }
        public ObservableCollection<Person> KundenListe { get; set; }
        public ObservableCollection<Status> Statusse { get; set; }

        private CurrySupportContext dbContext;
    }
}
