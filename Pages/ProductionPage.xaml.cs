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
        public ProductionPage(Model1 cont)
        {
            InitializeComponent();
            context = cont;
            Orders.ItemsSource = context.Purchase.ToList();
            var categoryList = context.Purchase.ToList();
            categoryList.Insert(0, new Purchase() { PaymentType = "Все" });
            //categoryList.Insert(0, new Purchase() { Delivery = true && false });
            CategoryBox.ItemsSource = categoryList;
            CategoryBox.SelectedIndex = 0;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PurchasePage(context));
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Purchase purchase = Orders.SelectedItem as Purchase;
            NavigationService.Navigate(new PurchasePage(context, purchase));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно желаете удалить заказ?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Purchase purchase = Orders.SelectedItems as Purchase;
                    context.Purchase.Remove(purchase);
                    context.SaveChanges();
                    Orders.ItemsSource = context.Purchase.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        void FilterData()
        {
            var list = context.Purchase.ToList();
            if (CategoryBox.SelectedIndex != 0)
            {
                Purchase purсhase = CategoryBox.SelectedItem as Purchase;
                list = list.Where(x => x.PaymentType == purсhase.PaymentType).ToList();
            }
            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                list = list.Where(x => x.Client.FIO.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            }
            Orders.ItemsSource = list;
        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

        private void ChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }
    }
}
