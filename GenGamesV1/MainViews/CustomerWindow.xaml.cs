using GenGamesV1.AddViews;
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
using GenGamesV1.AddViews;
using GenGamesV1.EditViews;

namespace GenGamesV1.MainViews
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
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
            CollectionViewSource collectionViewSource = (CollectionViewSource)FindResource("tblCustomerViewSource");
            // Create context to interact with the database

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            collectionViewSource.Source = context.tblCustomers.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow Window = new AddCustomerWindow();
            Window.Show();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateTable();
        }

        private int CustomerID;

        private void Datagrid_SelectedItemsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (tblCustomerDataGrid.SelectedItems.Count != 0)
            {
                // Assuming 'CategoryID' is a property of your data model
                var selectedItem = tblCustomerDataGrid.SelectedItems[0];
                int customerId = (int)selectedItem.GetType().GetProperty("CustomerID").GetValue(selectedItem);
                // Use 'categoryId' as needed
                CustomerID = customerId;
            }
        }

        private void AddBtn_Click_1(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow Window = new AddCustomerWindow();
            Window.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditCustomerWindow Window = new EditCustomerWindow(CustomerID);
            Window.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to remove CategoryID: {CustomerID} from the Database?", "Remove Category", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var context = new GenericGamesWPFEntities();
                var Entry = context.tblCustomers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();

                context.tblCustomers.Remove(Entry);
                context.SaveChanges();
                MessageBox.Show($"CategoryID: {CustomerID} has been deleted from the Database.");
                PopulateTable();
            }
        }
    }
}
