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

namespace CreatePC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> Nvidia = new List<string>() { "Не выбрано", "GTX 1050 - 10000 р.", "RTX 3060 - 14000 р.", "RTX 3080  - 20000 р." };
        List<string> Amd = new List<string>() { "Не выбрано", "RX 6000 - 10000 р.", "RX 6700 - 12000 р.", "RX 9000x - 100000 р." };
        private void Recalc(object sender, RoutedEventArgs e)
        {
            double price = 0;

            if (rbWin.IsChecked == true) { price += 7000; }
            if (rbWin.IsChecked == true) { price += 2000; }

            if (rbKasp.IsChecked == true) { price += 3000; }
            if (rbSpider.IsChecked == true) { price += 1500; }
            if (rb360.IsChecked == true) { price += 5000; }
            
            if (cbBl.IsChecked == true) { price += 500; }
            if (cbEt.IsChecked == true) { price += 250; }
            if (cbSc.IsChecked == true) { price += 1500; }
            if (cbCd.IsChecked == true) { price += 1000; }

            if (rbAmd.IsChecked == true) { price += 5000; }
            if (rbIntel.IsChecked == true) { price += 10000; }

            if (rb60.IsChecked == true) { price += 500; }
            if (rb70.IsChecked == true) { price += 1000; }
            if (rb80.IsChecked == true) { price += 1500; }
            if (rb90.IsChecked == true) { price += 2000; }

            if (rbNv.IsChecked == true) {
                
                switch (cboxVideoCard.SelectedIndex)
                {
                    case 0: break;
                    case 1: price += 10000; break;
                    case 2: price += 14000; break;
                    case 3: price += 20000; break;
                }
            }
            if (rbAm.IsChecked == true) {

                switch (cboxVideoCard.SelectedIndex)
                {
                    case 0: break;
                    case 1: price += 10000; break;
                    case 2: price += 12000; break;
                    case 3: price += 100000; break;
                }
            }

    

            if (rbBase.IsChecked == true) {
                cboxVideoCard.ItemsSource = null;
                price += 12790;
            }

          

            if (rbGig.IsChecked == true) { price += 2000; }
            if (rbAss.IsChecked == true) { price += 1500; }

            if (rb05.IsChecked == true) { price += 500; }
            if (rb15.IsChecked == true) { price += 1500; }
            if (rb2.IsChecked == true) { price += 4000; }
            if (rb4.IsChecked == true) { price += 8000; }
            
            if (cbCreatePc.IsChecked == true) { price += 2500; }


            tbPrice.Text = price.ToString();
        }

        private void rbNv_Checked(object sender, RoutedEventArgs e)
        {
            cboxVideoCard.ItemsSource = Nvidia;
            cboxVideoCard.SelectedIndex = 0;
        }

        private void rbAm_Checked(object sender, RoutedEventArgs e)
        {
            cboxVideoCard.ItemsSource = Amd;
            cboxVideoCard.SelectedIndex = 0;
        }
    }
}
