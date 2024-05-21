using GenGamesV1.AddViews;
using GenGamesV1.EditViews;
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

namespace GenGamesV1.MainViews
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            try
            {
                // Initialise the window and populate the table
                InitializeComponent();

                PopulateTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error.\n" + ex.Message);
            }
        }

        private void PopulateTable()
        {
            // Retrieve the collectionViewSource
            CollectionViewSource collectionViewSource = (CollectionViewSource)FindResource("tblOrderViewSource");
            // Create context to interact with the database

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            collectionViewSource.Source = context.tblOrders.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow Window = new AddOrderWindow();
            Window.Show();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateTable();
        }

        private int OrderID;

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditOrderWindow Window = new EditOrderWindow(OrderID);
            Window.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to remove CategoryID: {OrderID} from the Database?", "Remove Category", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var context = new GenericGamesWPFEntities();
                var Entry = context.tblCustomers.Where(c => c.CustomerID == OrderID).FirstOrDefault();

                context.tblCustomers.Remove(Entry);
                context.SaveChanges();
                MessageBox.Show($"CategoryID: {OrderID} has been deleted from the Database.");
                PopulateTable();
            }
        }
    }
}
