using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Логика взаимодействия для ProductionPage.xaml
    /// </summary>
    public partial class ProductionPage : Page
    {
        Model1 context;
        public ProductionPage(Model1 _cont)
        {
            InitializeComponent();
            context = _cont;
            Orders.ItemsSource = context.Purchase.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PurchasePage(context));
        }
    }
}
