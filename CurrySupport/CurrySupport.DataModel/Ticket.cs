using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Ticket
    {
        public Ticket()
        {
            // Damit nie null zurückgegeben wird
            Personen = new ObservableCollection<Person>();
        }

        public int Id { get; set; }

        [Required]
        public string Beschreibung { get; set; }

        [Required]
        public int Priorität { get; set; }

        public DateTime Erstellungsdatum { get; set; }

        public DateTime Aenderungsdatum { get; set; }

        public virtual ObservableCollection<Person> Personen { get; set; }

        [Required]
        public virtual Kategorie Kategorie { get; set; }

        public virtual Unterkategorie Unterkategorie { get; set; }

        public virtual Status Status { get; set; }
    }
}
