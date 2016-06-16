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
            var dbContext = new CurrySupportContext();
            Ticket = new Ticket();
        }

        public TicketViewModel(int ticketId)
        {
            var dbContext = new CurrySupportContext();
            Ticket = dbContext.AlleTickets.Find(ticketId);
        }

        private CurrySupportContext dbContext;
        public Ticket Ticket { get; set; }
    }
}
