using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Playerok
{
    /// <summary>
    /// Логика взаимодействия для AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public AddGame()
        {
            InitializeComponent();



            List<CetagoriesGames> categoriesGames = App.Entities.CetagoriesGames.ToList();
            cbCategory.ItemsSource = categoriesGames;
            cbCategory.DisplayMemberPath = "Name";
            cbCategory.SelectedValuePath = "Id";
            cbCategory.SelectedIndex = 0;

            List<DevelopersGames> developersGames = App.Entities.DevelopersGames.ToList();
            cbDeveloper.ItemsSource = developersGames;
            cbDeveloper.DisplayMemberPath = "Name";
            cbDeveloper.SelectedValuePath = "Id";
            cbDeveloper.SelectedIndex = 0;
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
          
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Изображения|*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == true)
            {
                string fileName = System.IO.Path.GetFileName(dialog.FileName);

                System.IO.File.Copy(dialog.FileName, $"../../Resources/GamesImages/{fileName}", true);
                
                tbimgName.Text = fileName;
                imgPrew.Source = new BitmapImage(new Uri(dialog.FileName));
            }

        }

        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {

            NamesGames name = new NamesGames();

            name.Name = tbxName.Text;
            App.Entities.NamesGames.Add(name);
            App.Entities.SaveChanges();

            Games game = new Games();

            game.NameGameId = name.Id;
            game.DeveloperGameId = (int)cbDeveloper.SelectedValue;
            game.CatygoryGameId = (int)cbCategory.SelectedValue;
            game.Description = tbxName.Text;
            game.Cost = Convert.ToDecimal(tbxName.Text);
            game.Photo = tbimgName.Text;
            App.Entities.Games.Add(game);

            App.Entities.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
            
        }

     
    }
}
