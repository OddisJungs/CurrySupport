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
            Construct();
        }

        public TicketViewModel(int ticketId)
        {
            dbContext = new CurrySupportContext();
            Ticket = dbContext.AlleTickets.Find(ticketId);
            Construct();
        }
        private void Construct()
        {
            PersonenListe = new ObservableCollection<Person>(dbContext.AllePersonen.ToList());
            Kategorien = new ObservableCollection<Kategorie>(dbContext.AlleKategorien.ToList());
            Unterkategorien = new ObservableCollection<Unterkategorie>(dbContext.AlleUnterkategorien.ToList());
            Statusse = new ObservableCollection<Status>(dbContext.AlleStatusse.ToList());
        }

        public Ticket Ticket { get; set; }
        public ObservableCollection<Kategorie> Kategorien { get; set; }
        public ObservableCollection<Unterkategorie> Unterkategorien { get; set; }
        public ObservableCollection<Person> PersonenListe { get; set; }
        public ObservableCollection<Status> Statusse { get; set; }


        private CurrySupportContext dbContext;
    }
}
