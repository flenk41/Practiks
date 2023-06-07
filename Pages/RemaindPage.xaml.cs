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
            var a = Convert.ToInt32(TabBox.Text);
            var b = LogBox.Text;
            var result = context.Users.Where(x => x.TableID == a && x.Login == b).ToString();

            if(result.Count() > 0 ) { 
                Users users = context.Users.ToList().Find(x => x.TableID.Equals(b));
                string show = users.Pass.ToString();
                MessageBox.Show(show);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка! Пользователь не найден.");
                this.Close();
            }
        }
    }
}
