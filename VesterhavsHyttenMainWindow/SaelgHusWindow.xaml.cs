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
using VesterhavsHyttenBIZ;
using VesterhavsHyttenDB;

namespace VesterhavsHyttenMainWindow
{
    /// <summary>
    /// Interaction logic for SaelgHusWindow.xaml
    /// </summary>
    public partial class SaelgHusWindow : Window
    {
        DBSaelgHus db = new DBSaelgHus();
        List<Udbyder> udbyder = new List<Udbyder>();
        List<Kunde> kunder = new List<Kunde>();

        List<Grund> grunde = new List<Grund>();
        List<Grund> grunde2Show = new List<Grund>();

        List<HusType> hustyper = new List<HusType>();
        List<HusType> hustyper2Show = new List<HusType>();

        List<Salg> salg = new List<Salg>();

        public SaelgHusWindow()
        {
            InitializeComponent();
            try { udbyder = db.getUdbyderList(); } catch { MessageBox.Show("Det var ikke muligt at hente udbydere fra databasen"); }
            try { kunder = db.getKundeList(); } catch { MessageBox.Show("Det var ikke muligt at hente kunder fra databasen"); }
            try { grunde = db.getGrundeList(); } catch { MessageBox.Show("Det var ikke muligt at hente grunde fra databasen"); }
            try { hustyper = db.getHustyperList(); } catch { MessageBox.Show("Det var ikke muligt at hente hustyper fra databasen"); }
            try { salg = db.getSalgList(); } catch { MessageBox.Show("Det var ikke muligt at hente salg fra databasen"); }

            dataGridUdbyder.ItemsSource = udbyder;
            dataGridKunder.ItemsSource = kunder;
            dataGridGrunde.ItemsSource = grunde2Show;
            dataGridHustyper.ItemsSource = hustyper2Show;
            dataGridSalg.ItemsSource = salg;
        }

        private void dataGridSalg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Salg selectedSalg = (Salg)dataGridSalg.SelectedItem;

            lblKundeNavn.Content = selectedSalg.Kunde.Navn;
            lblGrundAdresse.Content = selectedSalg.Grund.Adresse;
            lblHustypeNavn.Content = selectedSalg.HusType.Navn;
        }

        private void dataGridUdbyder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridGrunde.UnselectAll();
            dataGridHustyper.UnselectAll();

            Udbyder selectedUdbyder = (Udbyder)dataGridUdbyder.SelectedItem;

            if (hustyper2Show.Count > 0)
            {
                hustyper2Show.Clear();
            }
            if (grunde2Show.Count > 0)
            {
                grunde2Show.Clear();
            }

            foreach (HusType h in selectedUdbyder.getHustyper())
            {
                hustyper2Show.Add(h);
            }

            foreach (Grund g in grunde)
            {
                if (selectedUdbyder.Filial.Navn.ToUpper() == g.Filial.Navn.ToUpper())
                {
                    grunde2Show.Add(g);
                }
            }

            dataGridHustyper.Items.Refresh();
            dataGridGrunde.Items.Refresh();
        }

        private void btnSaelg_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUdbyder.SelectedItem != null &&
                dataGridKunder.SelectedItem != null &&
                dataGridGrunde.SelectedItem != null &&
                dataGridHustyper.SelectedItem != null)
            {
                Kunde sKunde = (Kunde)dataGridKunder.SelectedItem;
                Grund sGrund = (Grund)dataGridGrunde.SelectedItem;
                Udbyder sUdbyder = (Udbyder)dataGridUdbyder.SelectedItem;
                HusType sHusTyper = (HusType)dataGridHustyper.SelectedItem;

                MessageBoxResult messageBoxResult = MessageBox.Show($"Vil du oprette dette salg? \n\n\n Kunde: {sKunde.ToString()} \n \n Udbyder: {sUdbyder.ToString()} \n\n Grund: {sGrund.ToString()} \n\n Hustype: {sHusTyper.ToString()} \n\n Pris: {sGrund.Tillæg + sUdbyder.Pris}KR.", "Bekræftelse", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    //Salg createdSale = new Salg();

                    try
                    {
                        Salg createdSalg = new Salg(sHusTyper, sGrund, sKunde, sGrund.Tillæg + sUdbyder.Pris);
                        db.createSalg(createdSalg);

                        MessageBox.Show("SUCCESS!");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Det var ikke muligt at oprette salget");
                    }
                }

            }
            else
            {
                MessageBox.Show("Der skal vælges en kolonne i hver datagrid", "Advarsel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
