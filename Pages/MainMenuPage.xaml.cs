﻿using System;
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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    /// 
    public partial class MainMenuPage : Page
    {
        Window Window;
        Model1 _context;
        public MainMenuPage(Model1 context, Window window)
        {
            InitializeComponent();
            Window = window;
            _context = context;
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void OrderButton(object sender, RoutedEventArgs e)
        {
            FrameToBasePage.Navigate(new ProductionPage(_context));
        }
    }
}
