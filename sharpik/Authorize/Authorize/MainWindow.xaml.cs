using Authorize.Model;
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

namespace Authorize
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
        
        }

        int countTry = 3;

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {

            string login = tbxLogin.Text;
            string password = tbxPassword.Password;

            var maybeUser = App.Entities.Users.FirstOrDefault(u => u.Login == login);

            if (maybeUser != null)
            {

                if (maybeUser.Password == password)
                {
                    if (maybeUser.Block == false)
                    {

                        MessageBox.Show($"Вы успешно авторизовались ваша роль {maybeUser.Role}", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);

                        if (maybeUser.Role == "admin")
                        {
                            AdminPanel adminPanel = new AdminPanel();
                            adminPanel.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Вы заблокированы в системе! Обратитесь к администратору", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                   
                    countTry--;
                    if (countTry == 0)
                    {

                        MessageBox.Show("Вы заблокированы в системе! Обратитесь к администратору", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                        maybeUser.Block = true;
                        App.Entities.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("Неправильно введен логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

            
            


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
