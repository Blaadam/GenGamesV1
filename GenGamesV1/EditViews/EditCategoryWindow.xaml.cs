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

namespace GenGamesV1.EditViews
{
    /// <summary>
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private int SelectedCategoryID;
        public EditCategoryWindow(int CategoryID)
        {
            InitializeComponent();
            SelectedCategoryID = CategoryID;

            Edit_LabelID.Content = "Category ID: " + SelectedCategoryID.ToString();

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            var Row = context.tblCategories.Where(c => c.CategoryID == SelectedCategoryID).FirstOrDefault();
            Edit_CategoryDescTb.Text = Row.CategoryDescription;
            Edit_CategoryNameTb.Text = Row.CategoryName;
        }

        private void Edit_Category_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GenericGamesWPFEntities())
            {
                string inputCategoryName = Edit_CategoryNameTb.Text;
                string inputCategoryDesc = Edit_CategoryDescTb.Text;

                var editCategory = context.tblCategories.Where(c => c.CategoryID == SelectedCategoryID).FirstOrDefault();
                editCategory.CategoryName = inputCategoryName;
                editCategory.CategoryDescription = inputCategoryDesc;

                context.SaveChanges();

                MessageBox.Show("This Category has been Edited!", "Generic Games v1.0 Add Category", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }

        private void Edit_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_CategoryDescTb.Clear();
            Edit_CategoryNameTb.Clear();
        }
    }
}
