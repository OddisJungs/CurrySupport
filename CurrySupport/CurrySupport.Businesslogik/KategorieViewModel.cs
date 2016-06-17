using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrySupport.DataModel;

namespace CurrySupport.Businesslogik
{
    public class KategorieViewModel : BaseViewModel
    {
        private Kategorie ausgewaehlteKategorie;
        private Unterkategorie ausgewaehlteUnterkategorie;
        private CurrySupportContext dbContext;

        public KategorieViewModel()
        {
            dbContext = new CurrySupportContext();
            Kategorien = new ObservableCollection<Kategorie>(dbContext.AlleKategorien);
            ausgewaehlteKategorie = new Kategorie();
            ausgewaehlteUnterkategorie = new Unterkategorie();
        }

        public ObservableCollection<Kategorie> Kategorien { get; set; }

        public Kategorie AusgewaehlteKategorie
        {
            get
            {
                return ausgewaehlteKategorie;
            }
            set
            {
                ausgewaehlteKategorie = value;
                RaisePropertyChanged("AusgewaehlteKategorie");
            }
        }

        public Unterkategorie AusgewaehlteUnterkategorie
        {
            get
            {
                return ausgewaehlteUnterkategorie;
            }
            set
            {
                ausgewaehlteUnterkategorie = value;
                RaisePropertyChanged("AusgewaehlteUnterkategorie");
            }
        }

        public void KategorieHinzufuegen()
        {
            Kategorie neueKategorie = new Kategorie();
            neueKategorie.Bezeichnung = "Neue Kategorie";
            neueKategorie.Aktiv = true;
            dbContext.AlleKategorien.Add(neueKategorie);
            Kategorien.Add(neueKategorie);
            dbContext.SaveChanges();
        }

        public void UnterkategorieHinzufuegen()
        {
            if (ausgewaehlteKategorie != null) 
            {
                Unterkategorie neueUnterkategorie = new Unterkategorie();
                neueUnterkategorie.Bezeichnung = "Neue Unterkategorie";
                neueUnterkategorie.Kategorie = ausgewaehlteKategorie;
                neueUnterkategorie.Aktiv = true;
                ausgewaehlteKategorie.Unterkategorien.Add(neueUnterkategorie);
                dbContext.AlleUnterkategorien.Add(neueUnterkategorie);
                dbContext.SaveChanges();
            }
        }

        public void AusgewaehlteKategorieLoeschen()
        {
            if (dbContext.AlleKategorien.Find(ausgewaehlteKategorie.Id) != null)
            {
                dbContext.AlleKategorien.Remove(ausgewaehlteKategorie);
                Kategorien.Remove(ausgewaehlteKategorie);
                dbContext.SaveChanges();
            }
            ausgewaehlteKategorie = new Kategorie();
        }

        public void AusgewaehlteUnterkategorieLoeschen()
        {
            if (dbContext.AlleUnterkategorien.Find(ausgewaehlteUnterkategorie.Id) != null)
            {
                dbContext.AlleUnterkategorien.Remove(ausgewaehlteUnterkategorie);
                ausgewaehlteKategorie.Unterkategorien.Remove(ausgewaehlteUnterkategorie);               
                dbContext.SaveChanges();
            }
            ausgewaehlteUnterkategorie = new Unterkategorie();
        }

    }
}
