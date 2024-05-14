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
using GenGamesV1.MainViews;

namespace GenGamesV1.MainViews
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            try
            {
                // Initialise the window and populate the table
                InitializeComponent();

                PopulateTable();

            }
            catch(Exception ex) {
                MessageBox.Show("There has been an error.\n"+ex.Message);
            }
        }

        private void PopulateTable()
        {
            // Retrieve the collectionViewSource
            CollectionViewSource collectionViewSource = (CollectionViewSource)FindResource("tblCategoryViewSource");
            // Create context to interact with the database

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            collectionViewSource.Source = context.tblCategories.ToList(); ;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow Window = new AddCategoryWindow();
            Window.Show();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateTable ();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource tblCategoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tblCategoryViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // tblCategoryViewSource.Source = [generic data source]
        //}
    }
}
