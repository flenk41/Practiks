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
using System.Windows.Threading;

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        Model1 context;
        Window Window;
        public Autorization(Model1 cont, Window window)
        {
            InitializeComponent();
            context = cont;
            Remaind.Visibility = Visibility.Collapsed;
            Window = window;
        }

        int countClick = 0;
        private void Logining(object sender, RoutedEventArgs e)
        {
            countClick++;
            string log = LoginBox.Text;
            string pas = PasswordBox.Password;
            Users users = context.Users.ToList().Find(x=> x.Login.Equals(log));
            if (users != null)
            {
                if(users.Pass.Equals(pas)) {
                    NavigationService.Navigate(new MainMenuPage(context, Window));
                    countClick = 0;
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный пароль");
                    if(countClick >= 3)
                    {
                        Remaind.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
                if (countClick >= 3)
                {
                    Remaind.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            RegistrationPage regWindow = new RegistrationPage(context);
            regWindow.Show();
        }

        private void Remaind_Click(object sender, RoutedEventArgs e)
        {
            Users users = context.Users.Find(LoginBox.Text);
            NavigationService.Navigate(new RemaindPage(users));
        }
    }
}
