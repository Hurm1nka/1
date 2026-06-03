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
using System.Windows.Shapes;

namespace Authorize
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();


            SetComboBoxInfo();
            cbRole.SelectedIndex = 0;
            cbSetRole.SelectedIndex = 0;
            cbUsers.SelectedIndex = 0;
            

            EditInfo();

        }

        private void SetComboBoxInfo()
        {
            List<Users> users = App.Entities.Users.ToList();
            cbUsers.ItemsSource = users;
            cbUsers.DisplayMemberPath = "Login";
            cbUsers.SelectedValuePath = "Id";

            List<string> roles = App.Entities.Users.Select(u => u.Role).Distinct().ToList();
            cbRole.ItemsSource = roles;


            cbSetRole.ItemsSource = roles;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<Users> users = App.Entities.Users.ToList();
            
            Users addUser = new Users();
            addUser.Login = tbxSetLogin.Text;
            addUser.Password = tbxSetPassword.Text;
            addUser.Role = cbSetRole.SelectedItem.ToString();
            addUser.Block = Convert.ToBoolean(cbxBlock.IsChecked);


            if (!users.Any(u => u.Login == addUser.Login))
            {
                App.Entities.Users.Add(addUser);
                App.Entities.SaveChanges();
                MessageBox.Show("Пользователь успешно добавлен", "Добавление пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Добавление пользователя", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            SetComboBoxInfo();


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Users editUser = App.Entities.Users.FirstOrDefault(u => u.Id == (int)cbUsers.SelectedValue);

            editUser.Login = tbxLogin.Text;
            editUser.Password = tbxPassword.Text;
            editUser.Role = cbRole.SelectedItem.ToString();
            editUser.Block = Convert.ToBoolean(cbxBlock.IsChecked);

            App.Entities.SaveChanges();


            MessageBox.Show("Пользователь успешно изменен", "Изменение пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
         

        private void EditInfo()
        {
            List<Users> users = App.Entities.Users.ToList();

            var currentUser = users.FirstOrDefault(u => u.Id == (int)cbUsers.SelectedValue);

            if (currentUser != null)
            {
                tbxLogin.Text = currentUser.Login;
                tbxPassword.Text = currentUser.Password;
                cbRole.SelectedItem = currentUser.Role;

                if (currentUser.Block == true)
                {
                    cbxBlock.IsChecked = true;
                }
                else
                {
                    cbxBlock.IsChecked = false;
                }
            }

            SetComboBoxInfo();
        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditInfo();
        }
    }
}
