using Playerok.Model;
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

namespace Playerok
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string search;

        public MainWindow()
        {
            InitializeComponent();

            App.Entities = new Model.Entities();
            getGames();

            List<Model.CetagoriesGames> cetagoriesGames = App.Entities.CetagoriesGames.ToList();

            CetagoriesGames allCategories = new CetagoriesGames();
           
            allCategories.Id = 0;
            allCategories.Name = "Все жанры";

            cetagoriesGames.Insert(0, allCategories);

            cbCategory.ItemsSource = cetagoriesGames;
            cbCategory.DisplayMemberPath = "Name";
            cbCategory.SelectedValuePath = "Id";
            cbCategory.SelectedIndex = 0;
        }

        private void getGames()
        {
            List<Games> games = App.Entities.Games.ToList();

            if (rbUp.IsChecked == true) { games = App.Entities.Games.OrderBy(g => g.Cost).ToList(); }
            if (rbDown.IsChecked == true) { games = App.Entities.Games.OrderByDescending(g => g.Cost).ToList(); }


            if(cbCategory.SelectedIndex > 0)
            {
                games = games.Where(g => g.CetagoriesGames.Id == cbCategory.SelectedIndex).ToList();
            }

            if (tbxSearch.Text != "")
            {
                search = tbxSearch.Text;
                games = games.Where(g => g.NamesGames.Name.Contains(search) || g.CetagoriesGames.Name.Contains(search)
                                                      || g.Description.Contains(search)).ToList();
            }


           lbGames.ItemsSource = games;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void rbUp_Checked(object sender, RoutedEventArgs e)
        {
            getGames();
        }

        private void rbDown_Checked(object sender, RoutedEventArgs e)
        {
            getGames();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            getGames();
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getGames();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.Show();
            this.Hide();
        }
    }
}
