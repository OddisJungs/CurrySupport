﻿using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class TicketListeViewModel
    {
        public TicketListeViewModel()
        {
            var dbContext = new CurrySupportContext();
            Tickets = new ObservableCollection<Ticket>(dbContext.AlleTickets.ToList());
        }

        public ObservableCollection<Ticket> Tickets { get; set; }
    }
}
