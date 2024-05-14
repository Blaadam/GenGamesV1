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

namespace GenGamesV1.MainViews
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
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
            CollectionViewSource collectionViewSource = (CollectionViewSource)FindResource("tblProductViewSource");
            // Create context to interact with the database

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            collectionViewSource.Source = context.tblProducts.ToList(); ;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow Window = new AddProductWindow();
            Window.Show();
        }
    }
}
