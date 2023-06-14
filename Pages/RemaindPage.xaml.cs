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
        Model1 context;
        public RemaindPage(Model1 cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void RemaindClick(object sender, RoutedEventArgs e)
        {
            string log = LogBox.Text;
            int num = Convert.ToInt32(TabBox.Text);
            Users user = context.Users.Find(log);
            if(user != null)
            {
                if (user.TableID == num)
                {
                    MessageBox.Show(user.Pass, "Пароль");
                }
                else
                {
                    MessageBox.Show("Введен не правильный id");
                }
            }
        }
    }
}
