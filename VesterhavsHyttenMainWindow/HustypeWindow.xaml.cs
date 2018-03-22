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
    /// Interaction logic for HustypeWindow.xaml
    /// </summary>
    public partial class HustypeWindow : Window
    {
        DBHustype db = new DBHustype();
        List<HusType> hustyper = new List<HusType>();

        public HustypeWindow()
        {
            InitializeComponent();
            try { hustyper = db.getHustypeList(); } catch { MessageBox.Show("Det var ikke muligt at hente listen med hustyper"); }
            dataGrid.ItemsSource = hustyper;
        }

        private void chkSlet_Checked(object sender, RoutedEventArgs e)
        {
            chkOpret.IsChecked = false;
        }

        private void chkOpret_Checked(object sender, RoutedEventArgs e)
        {
            chkSlet.IsChecked = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // opret hustype
            if (chkOpret.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(txtAreal.Text) &&
                    !string.IsNullOrEmpty(txtEtager.Text) &&
                    !string.IsNullOrEmpty(txtNavn.Text))
                {
                    bool noDuplicates = true;

                    foreach (HusType ht in hustyper)
                    {
                        if (ht.Navn == txtNavn.Text)
                        {
                            noDuplicates = false;
                        }
                    }

                    if (noDuplicates)
                    {
                        int areal;
                        int etager;
                        if (int.TryParse(txtAreal.Text, out areal) && int.TryParse(txtEtager.Text, out etager))
                        {
                            HusType ht = new HusType(etager, areal, txtNavn.Text);

                            try
                            {
                                db.insertNewHustype(ht);
                                MessageBox.Show("SUCCESS!");
                                this.Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Det var ikke muligt at oprette den nye hustype");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Areal og etager må kun indeholde heltal");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Hustype med dette navn {txtNavn.Text} eksistere allerede");
                    }
                }
                else
                {
                    MessageBox.Show("Tomme felter er ikke tilladt");
                }
            }
            //---------
            // slet hustype
            //--------
            else if(chkSlet.IsChecked == true)
            {
                if (dataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Du skal vælge hvilken hustype du vil slette");
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Er du sikker?", "Delete Confirmation", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        HusType ht = (HusType)dataGrid.SelectedItem;
                        try
                        {
                            db.deleteHusType(ht.Id);
                            MessageBox.Show("SUCCESS!");
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Det var ikke muligt at slette hustypen");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Du skal tjekke enten slet- eller opret-hustype af");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HusType selectedHustype = (HusType)dataGrid.SelectedItem;
            txtId.Text = selectedHustype.Id.ToString();
            txtNavn.Text = selectedHustype.Navn;
            txtEtager.Text = selectedHustype.Etager.ToString();
            txtAreal.Text = selectedHustype.Areal.ToString();
        }
    }
}
