using CurrySupport.Businesslogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrySupport.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TicketListeViewModel();
        }

        private void TabControl1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabItemTicketlist.IsSelected)
            {
                if (DataContext.GetType() != typeof(TicketListeViewModel))
                {
                    DataContext = new TicketListeViewModel();
                }
                TextBlockTicketList.Background = Brushes.Blue;
            }
            else
            {
                TextBlockTicketList.Background = Brushes.LightSkyBlue;
            }
            if (TabItemTicket.IsSelected)
            {
                TextBlockTicket.Background = Brushes.Blue;
                if (DataContext.GetType() != typeof(TicketViewModel))
                {
                    DataContext = new TicketViewModel();
                }
            }
            else
            {
                TextBlockTicket.Background = Brushes.LightSkyBlue;
            }
            if (TabItemKundenHistory.IsSelected)
            {
                TextBlockKundenHistory.Background = Brushes.Blue;
            }
            else
            {
                TextBlockKundenHistory.Background = Brushes.LightSkyBlue;
            }
            if (TabItemPersonen.IsSelected)
            {
                if (DataContext.GetType() != typeof(PersonenViewModel))
                {
                    DataContext = new PersonenViewModel();
                }
                TextBlockPersonen.Background = Brushes.Blue;
            }
            else
            {
                TextBlockPersonen.Background = Brushes.LightSkyBlue;
            }
            if (TabItemKategorien.IsSelected)
            {
                if (DataContext.GetType() != typeof(KategorieViewModel))
                {
                    DataContext = new KategorieViewModel();
                }
                TextBlockKategorien.Background = Brushes.Blue;
            }
            else
            {
                TextBlockKategorien.Background = Brushes.LightSkyBlue;
            }
        }

        private void TicketListBearbeitenButtonBearbeiten_OnClick(object sender, RoutedEventArgs e)
        {
            if (TicketList.SelectedItem != null)
            {
                dynamic item = TicketList.SelectedItem as dynamic;
                int ticketId = item.Id;

                TabItemTicketlist.IsSelected = false;
                TabItemTicket.IsSelected = true;

                DataContext = new TicketViewModel(ticketId);
            }
        }

        private void TicketListButtonLöschen_OnClick(object sender, RoutedEventArgs e)
        {
            if (TicketList.SelectedItem != null)
            {
                dynamic item = TicketList.SelectedItem as dynamic;
                int ticketId = item.Id;

                ((TicketListeViewModel) DataContext).AusgewähltesTicketLöschen(ticketId);
            }
        }

        private void PersonenHinzufügenButton_Click(object sender, RoutedEventArgs e)
        {
            ((PersonenViewModel)DataContext).PersonHinzufügen();
        }

        private void PersonenLöschenButton_Click(object sender, RoutedEventArgs e)
        {
            ((PersonenViewModel)DataContext).AusgewaehltePersonLöschen();
        }

        private void PersonenAbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            ((PersonenViewModel)DataContext).PersonAuswahlAufheben();
        }

        private void PersonenÜbernehmenButton_Click(object sender, RoutedEventArgs e)
        {
            ((PersonenViewModel)DataContext).AusgewaehltePersonÄnderungÜbernehmen();
        }

        private void TicketSaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool successfull = ((TicketViewModel)DataContext).SaveTicket();
            if (successfull == true)
            {
                TabItemTicketlist.IsSelected = true;
                TabItemTicket.IsSelected = false;
                DataContext = new TicketListeViewModel();
            }
        }
    }
}
