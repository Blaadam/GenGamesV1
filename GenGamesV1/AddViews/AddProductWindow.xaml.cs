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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void Add_Product_AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Product_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_ProductNameTb.Text = string.Empty;
            Add_ProductDescTb.Text = string.Empty;
            Add_ProductCategory.Text = string.Empty;
            Add_ProductSize.Text = string.Empty;
            Add_ProductWholesaleCost.Text = string.Empty;
            Add_ProductInStock.IsChecked = false;
            Add_ProductQuantity.Text = string.Empty;
            Add_ProductSerialNumber.Text = string.Empty;
        }
    }
}
