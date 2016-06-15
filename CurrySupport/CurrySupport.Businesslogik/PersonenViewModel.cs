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
            ausgewaehltePerson = new Person();
        }
        public ObservableCollection<Person> Personen { get; set; }
        public Person AusgewaehltePerson
        {
            get
            {
                return ausgewaehltePerson;
            }
            set
            {
                ausgewaehltePerson = value;
                RaisePropertyChanged("AusgewaehltePerson");
            }
        }

        public void PersonHinzufügen()
        {
            Person neuePerson = new Person();
            neuePerson.Name = "Person";
            neuePerson.Vorname = "Neue";
            neuePerson.Telefonnummer = "7777777777";
            neuePerson.Rolle = dbContext.AlleRollen.First();
            neuePerson.Adresse = "Neustrasse 2";
            dbContext.AllePersonen.Add(neuePerson);
            Personen.Add(neuePerson);
            dbContext.SaveChanges(); 
        }

        public void AusgewaehltePersonLöschen()
        {
            if (dbContext.AllePersonen.Find(ausgewaehltePerson.Id) != null)
            {
                dbContext.AllePersonen.Remove(ausgewaehltePerson);
                Personen.Remove(ausgewaehltePerson);
                dbContext.SaveChanges();
            }
            ausgewaehltePerson = new Person();
        }

        private Person ausgewaehltePerson;
        private CurrySupportContext dbContext;
    }
}
