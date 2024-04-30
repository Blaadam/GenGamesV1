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

namespace GenGamesV1.AddViews
{
    /// <summary>
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void Add_Category_AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GenericGamesWPFEntities())
            {
                string inputCategoryName = Add_CategoryNameTb.Text;
                string inputCategoryDesc = Add_CategoryDescTb.Text;

                var selectedCategory = (from user in context.tblCategories
                                    where user.CategoryName == inputCategoryName
                                    select user).FirstOrDefault();

                if (selectedCategory != null)
                {
                    MessageBox.Show("This Category already Exists.", "Generic Games v1.0 Add Category", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                tblCategory newCategory = new tblCategory();
                newCategory.CategoryName = inputCategoryName.Trim();
                newCategory.CategoryDescription = inputCategoryDesc.Trim();

                context.tblCategories.Add(newCategory);
                context.SaveChanges();

                MessageBox.Show("This Category has been Created", "Generic Games v1.0 Add Category", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }

        private void Add_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_CategoryNameTb.Text = string.Empty;
            Add_CategoryDescTb.Text = string.Empty;
        }
    }
}
