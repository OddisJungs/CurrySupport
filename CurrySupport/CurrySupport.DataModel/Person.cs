using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Person
    {
        public Person()
        {

        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Telefonnummer { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public bool Aktiv { get; set; }

        public virtual Rolle Rolle { get; set; }

        public virtual ObservableCollection<Ticket> KundenTickets { get; set; }

        public String VollerName
        {
            get { return Vorname + " " + Name; }
        }

    }
}
