using Apteka.Model;
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

namespace Apteka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.Entities = new Model.Entities();
            getMedicaments();

            
            List<Diagnoses> categoryDeiagnosis = App.Entities.Diagnoses.ToList();

            Diagnoses allDiagnoses = new Diagnoses();
            allDiagnoses.Id = 0;
            allDiagnoses.Name = "Все категории";
            categoryDeiagnosis.Insert(0, allDiagnoses);


            cbCategory.ItemsSource = categoryDeiagnosis;
            cbCategory.DisplayMemberPath = "Name";
            cbCategory.SelectedValuePath = "Id";
            cbCategory.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void getMedicaments()
        {
            List<Medications> medicaments = App.Entities.Medications.ToList();

            string search = tbxSearch.Text.ToLower().Trim();

            medicaments = medicaments.Where(m => m.MedicationsName.Name.ToLower().Contains(search) ||
                                            m.Manufacturers.Name.ToLower().Contains(search) ||
                                            m.Description.ToLower().Contains(search)).ToList();
                                            


            if (rbUp.IsChecked == true) { medicaments = medicaments.OrderBy(m => m.Cost).ToList(); }
            if (rbDown.IsChecked == true) { medicaments = medicaments.OrderByDescending(m => m.Cost).ToList(); }

            if (cbCategory.SelectedIndex != 0)
            {
                medicaments = medicaments.Where(m => m.DiagnosisId == cbCategory.SelectedIndex).ToList();
            }

            

            LbMedicaments.ItemsSource = medicaments;
        }

        private void rbUp_Checked(object sender, RoutedEventArgs e)
        {
            getMedicaments();
        }

        private void rbDown_Checked(object sender, RoutedEventArgs e)
        {
            getMedicaments();
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getMedicaments();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            getMedicaments();
        }
    }
}
