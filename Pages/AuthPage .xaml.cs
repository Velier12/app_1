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
using app_1.Pages;
using System.Data.Common;

namespace app_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void ButtonRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Page2());
        }

        private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AuthBox.Text) || string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            using (var db = new Dementev_practicEntities())
            {
                var user = db.users
                    .AsNoTracking()
                    .FirstOrDefault(u -> u.name == AuthBox.Text && u.password == PasswordBox.Text);
               
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }
    }
}
