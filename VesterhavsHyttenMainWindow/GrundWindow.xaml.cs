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
    /// Interaction logic for GrundWindow.xaml
    /// </summary>
    public partial class GrundWindow : Window
    {
        DBGrund db = new DBGrund();
        List<Grund> grunde = new List<Grund>();
        List<Filial> filialer = new List<Filial>();
        int counter = 0;
        public GrundWindow()
        {
            InitializeComponent();
            try { grunde = db.getGrundList(); } catch (Exception) { MessageBox.Show("Det var ikke muligt at hente listen med grunde fra databasen"); }
            dataGrid.ItemsSource = grunde;
            try { filialer = db.getFilialList(); } catch (Exception) { MessageBox.Show("Det var ikke muligt at hente listen med filialer fra databasen"); }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chkRediger.IsChecked == true || chkSletGrund.IsChecked == true)
            {
                Grund selectedGrund = (Grund)dataGrid.SelectedItem;

                txtFilialAdresse.Text = selectedGrund.Filial.getAdresse();
                txtFilialBy.Text = selectedGrund.Filial.getBy();
                txtFilialId.Text = selectedGrund.Filial.getId().ToString();
                txtFilialMail.Text = selectedGrund.Filial.getMail();
                txtFilialNavn.Text = selectedGrund.Filial.getNavn();
                txtFilialPostnr.Text = selectedGrund.Filial.getPostnr().ToString();
                txtFilialTelefon.Text = selectedGrund.Filial.getTelefon();
                txtGrundAdresse.Text = selectedGrund.Adresse;
                txtGrundAreal.Text = selectedGrund.getAreal().ToString();
                txtGrundBy.Text = selectedGrund.Postnr.Navn;
                txtGrundId.Text = selectedGrund.Id.ToString();
                txtGrundPostnr.Text = selectedGrund.Postnr.postnr.ToString();
                txtGrundTillaeg.Text = selectedGrund.getTillæg().ToString();
            }
            else
            {
                dataGrid.UnselectAll();
            }
        }

        private void btnFrem_Click(object sender, RoutedEventArgs e)
        {
            if (chkOpret.IsChecked == true)
            {
                if (counter < filialer.Count - 1)
                {
                    counter++;
                }
                txtFilialAdresse.Text = filialer[counter].getAdresse();
                txtFilialBy.Text = filialer[counter].getBy();
                txtFilialId.Text = filialer[counter].getId().ToString();
                txtFilialMail.Text = filialer[counter].getMail();
                txtFilialNavn.Text = filialer[counter].getNavn();
                txtFilialPostnr.Text = filialer[counter].getPostnr().ToString();
                txtFilialTelefon.Text = filialer[counter].getTelefon();
            }
        }

        private void btnTilbage_Click(object sender, RoutedEventArgs e)
        {
            if (chkOpret.IsChecked == true)
            {
                if (counter > 0)
                {
                    counter--;
                }
                txtFilialAdresse.Text = filialer[counter].getAdresse();
                txtFilialBy.Text = filialer[counter].getBy();
                txtFilialId.Text = filialer[counter].getId().ToString();
                txtFilialMail.Text = filialer[counter].getMail();
                txtFilialNavn.Text = filialer[counter].getNavn();
                txtFilialPostnr.Text = filialer[counter].getPostnr().ToString();
                txtFilialTelefon.Text = filialer[counter].getTelefon();
            }
        }

        private void chkRediger_Checked(object sender, RoutedEventArgs e)
        {
            chkOpret.IsChecked = false;

            txtFilialAdresse.Text = "";
            txtFilialBy.Text = "";
            txtFilialId.Text = "";
            txtFilialMail.Text = "";
            txtFilialNavn.Text = "";
            txtFilialPostnr.Text = "";
            txtFilialTelefon.Text = "";

            txtGrundAdresse.Text = "";
            txtGrundAreal.Text = "";
            txtGrundBy.Text = "";
            txtGrundId.Text = "";
            txtGrundPostnr.Text = "";
            txtGrundTillaeg.Text = "";

            btnFrem.IsEnabled = false;
            btnTilbage.IsEnabled = false;
        }

        private void chkOpret_Checked(object sender, RoutedEventArgs e)
        {
            chkRediger.IsChecked = false;
            counter = 0;

            txtGrundAdresse.Text = "";
            txtGrundAreal.Text = "";
            txtGrundBy.Text = "";
            txtGrundId.Text = "";
            txtGrundPostnr.Text = "";
            txtGrundTillaeg.Text = "";

            txtFilialAdresse.Text = filialer[counter].getAdresse();
            txtFilialBy.Text = filialer[counter].getBy();
            txtFilialId.Text = filialer[counter].getId().ToString();
            txtFilialMail.Text = filialer[counter].getMail();
            txtFilialNavn.Text = filialer[counter].getNavn();
            txtFilialPostnr.Text = filialer[counter].getPostnr().ToString();
            txtFilialTelefon.Text = filialer[counter].getTelefon();

            btnFrem.IsEnabled = true;
            btnTilbage.IsEnabled = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //opret nu grund
            if (chkOpret.IsChecked == true)
            {
                if (checkForEmptyGrundTXT())
                {
                    if (checkForEmptyFilialTXT() )
                    {
                        int postnr;
                        double tillaeg;
                        int areal;
                        if (int.TryParse(txtGrundPostnr.Text, out postnr) && double.TryParse(txtGrundTillaeg.Text, out tillaeg) && int.TryParse(txtGrundAreal.Text, out areal))
                        {
                            Filial selectedFilial = filialer[counter];
                            Postnr postn = new Postnr(postnr, txtGrundBy.Text);
                            Grund newGrund = new Grund(txtGrundAdresse.Text, postn, tillaeg, areal, selectedFilial);

                            try
                            {
                                db.InsertNewGrund(newGrund);

                                MessageBox.Show("Success!");
                                this.Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Det var ikke muligt at oprette den nye grund");
                            }
                        }
                        else
                        {
                            MessageBox.Show("postnummer må kun indeholde tal");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Du skal vælge en filial");
                    }
                }
                else
                {
                    MessageBox.Show("Tomme felter er ikke tilladt");
                }
            }
            // redigere grund
            else if (chkRediger.IsChecked == true)
            {
                if (dataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Du skal have valgt hvilken grund du vil redigere");
                }
                else
                {
                    if (checkForEmptyGrundTXT())
                    {
                        int postnr;
                        double tillaeg;
                        int areal;
                        if (int.TryParse(txtGrundPostnr.Text, out postnr) && double.TryParse(txtGrundTillaeg.Text, out tillaeg) && int.TryParse(txtGrundAreal.Text, out areal))
                        {
                            Grund selectedGrund = (Grund)dataGrid.SelectedItem;
                            Postnr post = new Postnr(postnr, txtGrundBy.Text);
                            Grund editedGrund = new Grund(txtGrundAdresse.Text, post, tillaeg, areal, Convert.ToInt32(txtGrundId.Text), selectedGrund.getFilial());

                            try
                            {
                                db.UpdateGrund(editedGrund);

                                MessageBox.Show("Success!");
                                this.Close();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Det var ikke muligt at redigere grunden");
                            }
                        }
                        else
                        {
                            MessageBox.Show("postnummer må kun indeholde tal");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tomme felter er ikke tilladt");
                    }
                }
            }
            else if (chkSletGrund.IsChecked == true)
            {
                if (dataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Du har ikke valgt en grund");
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Er du sikker?", "Delete Confirmation", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        Grund selectedGrund = (Grund)dataGrid.SelectedItem;
                        try
                        {
                            db.deleteGrund(selectedGrund.Id);

                            MessageBox.Show("Success!");
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Det var ikke muligt at slette grunden");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Du skal enten tjekke opret eller rediger af");
            }
            
        }

        private bool checkForEmptyFilialTXT()
        {
            if (string.IsNullOrEmpty(txtFilialAdresse.Text) ||
                string.IsNullOrEmpty(txtFilialBy.Text) ||
                string.IsNullOrEmpty(txtFilialMail.Text) ||
                string.IsNullOrEmpty(txtFilialNavn.Text) ||
                string.IsNullOrEmpty(txtFilialPostnr.Text) ||
                string.IsNullOrEmpty(txtFilialTelefon.Text) ||
                string.IsNullOrEmpty(txtFilialId.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkForEmptyGrundTXT()
        {
            if (string.IsNullOrEmpty(txtGrundAdresse.Text) ||
                string.IsNullOrEmpty(txtGrundAreal.Text) ||
                string.IsNullOrEmpty(txtGrundBy.Text) ||
                string.IsNullOrEmpty(txtGrundPostnr.Text) ||
                string.IsNullOrEmpty(txtGrundTillaeg.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
