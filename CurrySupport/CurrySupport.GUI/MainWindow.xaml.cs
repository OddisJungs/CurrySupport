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
            // TODO: Das könntest du schöner machen.. vieleicht so:foreach (TabItem item in TabControl1.Items.OfType<TabItem>())
            if (TabItemTicketlist.IsSelected)
            {
                TextBlockTicketList.Background = Brushes.Blue;
                DataContext = new TicketListeViewModel();
            }
            else
            {
                TextBlockTicketList.Background = Brushes.LightSkyBlue;
            }
            if (TabItemTicket.IsSelected)
            {
                TextBlockTicket.Background = Brushes.Blue;
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
                TextBlockPersonen.Background = Brushes.Blue;
            }
            else
            {
                TextBlockPersonen.Background = Brushes.LightSkyBlue;
            }
            if (TabItemKategorien.IsSelected)
            {
                TextBlockKategorien.Background = Brushes.Blue;
            }
            else
            {
                TextBlockKategorien.Background = Brushes.LightSkyBlue;
            }
        }
    }
}
