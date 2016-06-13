using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class PersonenViewModel
    {
        public PersonenViewModel()
        { 
            dbContext = new CurrySupportContext();
            Personen = new ObservableCollection<Person>(dbContext.AllePersonen);
        }

        private CurrySupportContext dbContext;
        public ObservableCollection<Person> Personen { get; set; }
        public Person SelectedPerson { get; set; }
    }
}
