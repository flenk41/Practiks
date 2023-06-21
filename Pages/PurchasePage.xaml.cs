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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        Model1 context;
        Purchase purchase;
        public PurchasePage(Model1 cont, Purchase pur)
        {
            InitializeComponent();
            context = cont;
            purchase = pur;
            ModelBox.ItemsSource = context.Product.ToList();
            FIOBox.ItemsSource = context.Client.ToList();
            ManagerBox.ItemsSource = context.Manager.ToList();
            PayBox.ItemsSource = context.Purchase.Distinct().ToList();
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void UpdateClick(object senderm, RoutedEventArgs e)
        {
            try
            {
                Product prod = ModelBox.SelectedItem as Product;
                Client client = FIOBox.SelectedItem as Client;
                Manager manager = ManagerBox.SelectedItem as Manager;

                purchase.CodeProduct = prod.Code;
                purchase.Product = prod;
                purchase.IdClient = client.Id;
                purchase.idManeger = manager.Id;
                purchase.DatePuschase = Convert.ToDateTime(DateTimeBox.Text);
                purchase.Delivery = DeliveryBox.Text.ToLower().Equals("да") ? true : false;
                purchase.PaymentType = PayBox.Text;
                purchase.Client = client;
                purchase.Manager = manager;
                context.SaveChanges();
                NavigationService.Navigate(new ProductionPage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void AddPurchClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = ModelBox.SelectedItem as Product;
                Client client = FIOBox.SelectedItem as Client;
                Manager manager = ManagerBox.SelectedItem as Manager;
                Purchase purchase = new Purchase()
                {
                    Id = context.Purchase.ToList().Last().Id + 1,
                    CodeProduct = product.Code,
                    Product = product,
                    IdClient = client.Id,
                    idManeger = manager.Id,
                    DatePuschase = Convert.ToDateTime(DateTimeBox.Text),
                    Delivery = DeliveryBox.Text.ToLower().Equals("да") ? true : false,
                    PaymentType = PayBox.Text,
                    Client = client,
                    Manager = manager
                };
                context.Purchase.Add(purchase);
                context.SaveChanges();
                NavigationService.Navigate(new PurchasePage(context)); //тут баг 
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка в вводимых данных");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
