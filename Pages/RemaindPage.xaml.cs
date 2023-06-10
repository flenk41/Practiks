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

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для RemaindPage.xaml
    /// </summary>
    public partial class RemaindPage : Window
    {
        Users userspass;
        public RemaindPage(Users usersp)
        {
            InitializeComponent();
            LogBox.Text = userspass.Login;
            userspass = usersp;
        }

        private void RemaindClick(object sender, RoutedEventArgs e)
        {
            if(userspass.Login == LogBox.Text && userspass.TableID==Convert.ToInt32(TabBox)) {
                MessageBox.Show($"Ваш пароль: {userspass.Pass}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
