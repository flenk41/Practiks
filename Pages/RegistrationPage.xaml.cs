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

namespace Practika.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        Model1 context;
        public RegistrationPage(Model1 cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void RegBut(object sender, RoutedEventArgs e)
        {
            Users user = new Users() 
            { 
                FIO = IFreg.Text, 
                Dolzhnost = Dreg.Text, 
                TableID = Convert.ToInt32(TNreg.Text), 
                Login = Logreg.Text, 
                Pass = Pasreg.Text 
            };
            context.Users.Add(user);
            context.SaveChanges();
            this.Close();

        }
    }
}
