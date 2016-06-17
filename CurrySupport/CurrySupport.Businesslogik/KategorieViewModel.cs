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

        public KategorieViewModel()
        {
            var dbContext = new CurrySupportContext();
            AlleKategorien = new ObservableCollection<Kategorie>(dbContext.AlleKategorien);
            ausgewaehlteKategorie = new Kategorie();
            ausgewaehlteUnterkategorie = new Unterkategorie();
        }

        public ObservableCollection<Kategorie> AlleKategorien { get; set; }

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

    }
}
