using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class PersonenViewModel : BaseViewModel
    {
        public PersonenViewModel()
        { 
            dbContext = new CurrySupportContext();
            Personen = new ObservableCollection<Person>(dbContext.AllePersonen);
            ausgewähltePerson = new Person();
        }
        public ObservableCollection<Person> Personen { get; set; }
        public Person AusgewähltePerson
        {
            get
            {
                return ausgewähltePerson;
            }
            set
            {
                ausgewähltePerson = value;
                RaisePropertyChanged("AusgewähltePerson");
            }
        }
        

        private Person ausgewähltePerson;
        private CurrySupportContext dbContext;
    }
}
