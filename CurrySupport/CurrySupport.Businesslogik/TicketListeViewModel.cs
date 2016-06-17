using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class TicketListeViewModel
    {
        public TicketListeViewModel()
        {
            dbContext = new CurrySupportContext();
            Tickets = new ObservableCollection<Ticket>(dbContext.AlleTickets.ToList());
        }

        public ObservableCollection<Ticket> Tickets { get; set; }

        public void AusgewähltesTicketLöschen(int pticketid)
        {
            Ticket ticketToRemove = GetTickeToRemove(pticketid);
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

        private CurrySupportContext dbContext;
    }
}
