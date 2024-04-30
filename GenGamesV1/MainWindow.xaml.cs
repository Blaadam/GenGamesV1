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

namespace GenGamesV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OrdersTab.Visibility = Visibility.Collapsed;
            ProductsTab.Visibility = Visibility.Collapsed;
            CustomersTab.Visibility = Visibility.Collapsed;
            CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersTab.Visibility = Visibility.Collapsed;
            ProductsTab.Visibility = Visibility.Collapsed;
            CustomersTab.Visibility = Visibility.Collapsed;
            CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Orders_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersTab.Visibility = Visibility.Visible;
            ProductsTab.Visibility = Visibility.Collapsed;
            CustomersTab.Visibility = Visibility.Collapsed;
            CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Products_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersTab.Visibility = Visibility.Collapsed;
            ProductsTab.Visibility = Visibility.Visible;
            CustomersTab.Visibility = Visibility.Collapsed;
            CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Customers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersTab.Visibility = Visibility.Collapsed;
            ProductsTab.Visibility = Visibility.Collapsed;
            CustomersTab.Visibility = Visibility.Visible;
            CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Categories_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OrdersTab.Visibility = Visibility.Collapsed;
            ProductsTab.Visibility = Visibility.Collapsed;
            CustomersTab.Visibility = Visibility.Collapsed;
            CategoriesTab.Visibility = Visibility.Visible;
        }

        private void ico_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
