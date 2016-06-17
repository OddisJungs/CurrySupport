using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Beschreibung { get; set; }

        public string Lösung { get; set; }

        [Required]
        public int Priorität { get; set; }

        public DateTime? Erstellungsdatum { get; set; }

        public DateTime? Aenderungsdatum { get; set; }

        [Required]
        public virtual Person Kunde{ get; set; }

        [Required]
        public virtual Person Bearbeiter{ get; set; }

        [Required]
        public virtual Kategorie Kategorie { get; set; }

        public virtual Unterkategorie Unterkategorie { get; set; }

        [Required]
        public virtual Status Status { get; set; }

        public String GetVollerKundenName
        {
            get { return Kunde.Vorname + " " + Kunde.Name; }
        }

        public String GetVollerBearbeiterName
        {
            get { return Bearbeiter.Vorname + " " + Bearbeiter.Name; }
        }

        public string GetDatumFormated
        {
            get
            {
                DateTime datum = new DateTime();
                if (Erstellungsdatum != null)
                {
                    datum = (DateTime)Erstellungsdatum;
                }
                return datum.ToString("d MMMM yyyy",CultureInfo.CurrentCulture);
            }
        }
    }
}
