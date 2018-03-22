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
using System.Windows.Shapes;
using VesterhavsHyttenDB;
using VesterhavsHyttenBIZ;

namespace VesterhavsHyttenMainWindow
{
    /// <summary>
    /// Interaction logic for ForspoergelserWindow.xaml
    /// </summary>
    public partial class ForspoergelserWindow : Window
    {
        List<Filial> filialer = new List<Filial>();
        dbForspøgelser db = new dbForspøgelser();

        public ForspoergelserWindow()
        {
            InitializeComponent();
       
            A7();

            B7();

            C7();

            D7();

            E7();

            F7();

            G7();

            H7();

            I7();
        }

        public void A7()
        {
            try
            {
                if (db.A7Exist())
                {
                    lbl7A.Content = "JA";
                }
                else
                {
                    lbl7A.Content = "NEJ";
                }
            }
            catch { MessageBox.Show("Forespørgelse A7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void B7()
        {
            try
            {
                filialer = db.B7FilialList();
                cbo7B.ItemsSource = filialer;
            }
            catch { MessageBox.Show("B7 Det var ikke muligt at indlæse filialer fra databasen", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void C7()
        {
            cbo7C.ItemsSource = filialer;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Filial filial = (Filial)cbo7B.SelectedItem;
                lbo7B.ItemsSource = db.B7Answer(filial.Navn);
            }
            catch { MessageBox.Show("Forespørgelse B7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void cbo7C_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Filial filial = (Filial)cbo7C.SelectedItem;
                lbo7C.ItemsSource = db.C7Answer(filial.Navn);
            }
            catch
            {
                MessageBox.Show("Forespørgelse C7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void D7()
        {
            try { lbo7D.ItemsSource = db.D7Answer(); } catch { MessageBox.Show("Forespørgwelse D7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void E7()
        {
            try { lbo7E.ItemsSource = db.E7(); } catch { MessageBox.Show("Forespørgelse E7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void F7()
        {
            cbo7F.ItemsSource = filialer;
        }

        private void cbo7F_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filial filial = (Filial)cbo7F.SelectedItem;
            try { lbo7F.ItemsSource = db.F7(filial.Navn); } catch { MessageBox.Show("Forespørgeæse F7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); } 
        }

        public void G7()
        {
            try { lbo7G.ItemsSource = db.G7(); } catch { MessageBox.Show("Forespørgelse G7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void H7()
        {
            try { lbo7H.ItemsSource = db.H7(); } catch { MessageBox.Show("Forespørgelse H7 fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void I7()
        {
            try { lbo7I.ItemsSource = db.I7(); } catch { MessageBox.Show("Forespørgelse I7 Fejlede", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
