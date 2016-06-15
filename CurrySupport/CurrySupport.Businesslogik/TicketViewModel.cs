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
            Ticket = new Ticket();
        }

        public TicketViewModel(object zuBearbeitendesTicket)
        {
            if (zuBearbeitendesTicket.GetType() == typeof(Ticket))
            {
                Ticket = (Ticket)zuBearbeitendesTicket;
            }
            else
            {
                throw new FormatException();
            }
        }

        public Ticket Ticket { get; set; }
    }
}
