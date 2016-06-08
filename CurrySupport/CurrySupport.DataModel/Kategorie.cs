using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Kategorie
    {
        public Kategorie()
        {
            // damit nie null zurückkommt
            Unterkategorien = new ObservableCollection<Unterkategorie>();
        }
        public int Id { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public bool Aktiv { get; set; }

        public virtual ObservableCollection<Unterkategorie> Unterkategorien { get; set; }
    }
}