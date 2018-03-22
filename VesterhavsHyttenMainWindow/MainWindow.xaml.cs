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

namespace VesterhavsHyttenMainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGrund_Clicked(object sender, RoutedEventArgs e)
        {
            GrundWindow gw = new GrundWindow();
            gw.ShowDialog();
        }

        private void btnForspoergelser_Clicked(object sender, RoutedEventArgs e)
        {
            ForspoergelserWindow fw = new ForspoergelserWindow();
            fw.ShowDialog();
        }

        private void btnAdminHustype_Click(object sender, RoutedEventArgs e)
        {
            HustypeWindow hw = new HustypeWindow();
            hw.ShowDialog();
        }

        private void btnMedarbejderSaelgHus_Click(object sender, RoutedEventArgs e)
        {
            SaelgHusWindow shw = new SaelgHusWindow();
            shw.ShowDialog();
        }

        private void cboPermision_checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbo = (CheckBox)sender;

            switch (cbo.Name)
            {
                case "cboAdmin":
                    cboEksternInter.IsChecked = false;
                    cboMedarbejder.IsChecked = false;
                    break;

                case "cboMedarbejder":
                    cboAdmin.IsChecked = false;
                    cboEksternInter.IsChecked = false;
                    break;

                case "cboEksternInter":
                    cboAdmin.IsChecked = false;
                    cboMedarbejder.IsChecked = false;
                    break;
            }
        }
    }
}
