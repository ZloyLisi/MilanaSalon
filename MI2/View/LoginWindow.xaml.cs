using MI2.Model;
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

namespace MI2.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = SalonBDEntities.GetContext().User.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password);

            if (user != null)
            {
                switch (user.IdRole)
                {
                    case 1:
                        var mainWindow = new MainWindow
                        {
                            EditButtonVisibility = Visibility.Collapsed,
                            DeletButtonVisibility = Visibility.Collapsed,
                           
                        };
                        mainWindow.AddUserButton.Visibility = Visibility.Collapsed;
                        mainWindow.AddDressButton.Visibility = Visibility.Collapsed;
                        mainWindow.UsersButton.Visibility = Visibility.Collapsed;

                        mainWindow.Show();
                        break;
                    case 2: // 
                        new MainWindow().Show();
                        break;
                   


                       
                       
                    default:
                        MessageBox.Show("Неизвестная роль пользователя.");
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }
    }
}
