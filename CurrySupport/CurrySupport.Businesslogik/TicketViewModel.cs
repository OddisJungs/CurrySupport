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
            personenListe = new ObservableCollection<Person>(dbContext.AllePersonen.ToList());
        }

        public Ticket Ticket { get; set; }

        public ObservableCollection<Person> PersonenListe
        {
            get { return personenListe; }
            set { personenListe = value; }
        }

        private ObservableCollection<Person> personenListe;
        private CurrySupportContext dbContext;
    }
}
