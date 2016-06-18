using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrySupport.DataModel;

namespace CurrySupport.Businesslogik
{
    public class KundenUebersichtViewModel : BaseViewModel
    {
        public KundenUebersichtViewModel()
        {
            dbContext = new CurrySupportContext();
            Tickets = new ObservableCollection<Ticket>(dbContext.AlleTickets.ToList());
            Kunden = new ObservableCollection<Person>(dbContext.AllePersonen.Where(x => x.Rolle.Bezeichnung.Equals("Kunde")).ToList());
        }

        public ObservableCollection<Ticket> Tickets { get; set; }

        public ObservableCollection<Person> Kunden { get; set; }

        public Person AusgewaehlterKunde
        {
            get
            {
                return ausgewaehlterKunde;
            }
            set
            {
                ausgewaehlterKunde = value;
                RaisePropertyChanged("AusgewaehlterKunde");
            }
        }

        public ObservableCollection<Ticket> GetTicketOfAusgewählterKunde()
        {
            return new ObservableCollection<Ticket>(Tickets.Where(x => x.Kunde == ausgewaehlterKunde).ToList());
        }

        private Person ausgewaehlterKunde;
        private CurrySupportContext dbContext;

        public void AusgewähltesTicketLöschen(int pticketId)
        {
            Ticket ticketToRemove = GetTickeToRemove(pticketId);
            if (ticketToRemove != null)
            {
                dbContext.AlleTickets.Remove(ticketToRemove);
                Tickets.Remove(ticketToRemove);
                dbContext.SaveChanges();
            }
        }
        private Ticket GetTickeToRemove(int pticketid)
        {
            return dbContext.AlleTickets.Find(pticketid);
        }
    }
}
