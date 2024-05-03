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
using GenGamesV1.MainViews;

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

            //OrdersTab.Visibility = Visibility.Collapsed;
            //ProductsTab.Visibility = Visibility.Collapsed;
            //CustomersTab.Visibility = Visibility.Collapsed;
            //CategoriesTab.Visibility = Visibility.Collapsed;
        }

        public void OpenPanel(Window newWindow)
        {
            // Clear
            pnl_ChildWindow.Children.Clear();

            var Content = newWindow.Content;

            newWindow.Content = null;
            newWindow.Close();

            pnl_ChildWindow.Children.Add(Content as UIElement);
        }

        private void ico_Home_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Title = "Generic Games v1.0 - Home";
            OpenPanel(new HomeWindow());

            //OrdersTab.Visibility = Visibility.Collapsed;
            //ProductsTab.Visibility = Visibility.Collapsed;
            //CustomersTab.Visibility = Visibility.Collapsed;
            //CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Orders_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Title = "Generic Games v1.0 - Orders";
            OpenPanel(new OrdersWindow());

            //OrdersTab.Visibility = Visibility.Visible;
            //ProductsTab.Visibility = Visibility.Collapsed;
            //CustomersTab.Visibility = Visibility.Collapsed;
            //CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Products_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Title = "Generic Games v1.0 - Products";
            OpenPanel(new ProductWindow());

            //OrdersTab.Visibility = Visibility.Collapsed;
            //ProductsTab.Visibility = Visibility.Visible;
            //CustomersTab.Visibility = Visibility.Collapsed;
            //CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Customers_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Title = "Generic Games v1.0 - Customers";
            OpenPanel(new CustomerWindow());

            //OrdersTab.Visibility = Visibility.Collapsed;
            //ProductsTab.Visibility = Visibility.Collapsed;
            //CustomersTab.Visibility = Visibility.Visible;
            //CategoriesTab.Visibility = Visibility.Collapsed;
        }

        private void ico_Categories_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Title = "Generic Games v1.0 - Categories";
            OpenPanel(new CategoryWindow());

            //OrdersTab.Visibility = Visibility.Collapsed;
            //ProductsTab.Visibility = Visibility.Collapsed;
            //CustomersTab.Visibility = Visibility.Collapsed;
            //CategoriesTab.Visibility = Visibility.Visible;
        }

        private void ico_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
