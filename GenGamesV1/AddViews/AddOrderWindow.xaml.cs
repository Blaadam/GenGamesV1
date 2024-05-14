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
    /// Interaction logic for AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        private void Add_Order_AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GenericGamesWPFEntities())
            {
                string inputCustomerID = Add_OrderCustomerID.Text.Trim();
                string inputCustomerSurname = Add_OrderCustomerSurname.Text.Trim();
                string inputHouseNumber = Add_OrderHouseNumber.Text.Trim();
                string inputAddress = Add_OrderAddress.Text.Trim();
                string inputPostCode = Add_OrderPostCode.Text.Trim();
                string inputCity = Add_OrderCity.Text.Trim();
                string inputCountry = Add_OrderCountry.Text.Trim();
                string inputProductID = Add_OrderProductID.Text.Trim();
                string inputProductName = Add_OrderProductName.Text.Trim();
                string inputQuantity = Add_OrderQuantity.Text.Trim();
                string inputCost = Add_OrderCost.Text.Trim();
                string inputShippingCost = Add_OrderShippingCost.Text.Trim();
                string inputFinalTotal = Add_OrderFinalTotal.Text.Trim();
                string inputStatus = Add_OrderStatus.Text.Trim();

                if (string.IsNullOrEmpty(inputCustomerID) || string.IsNullOrEmpty(inputCustomerSurname) || string.IsNullOrEmpty(inputHouseNumber) || string.IsNullOrEmpty(inputAddress) || string.IsNullOrEmpty(inputPostCode) || string.IsNullOrEmpty(inputCity) || string.IsNullOrEmpty(inputCountry) || string.IsNullOrEmpty(inputProductID) || string.IsNullOrEmpty(inputProductName) || string.IsNullOrEmpty(inputQuantity) || string.IsNullOrEmpty(inputCost) || string.IsNullOrEmpty(inputShippingCost) || string.IsNullOrEmpty(inputFinalTotal) || string.IsNullOrEmpty(inputStatus))
                {
                    MessageBox.Show("One or more field(s) are empty.", "Generic Games v1.0 Add Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectedUser = (from user in context.tblCustomers
                                        where user.CustomerID.ToString() == inputCustomerID
                                        select user).FirstOrDefault();

                if (selectedUser == null)
                {
                    MessageBox.Show("This CustomerID does not exist", "Generic Games v1.0 Add Order", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectedProduct = (from user in context.tblProducts
                                    where user.ProductID.ToString() == inputProductID
                                    select user).FirstOrDefault();

                if (selectedProduct == null)
                {
                    MessageBox.Show("This ProductID does not exist", "Generic Games v1.0 Add Order", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                tblOrder newOrder = new tblOrder();
                newOrder.CustomerID = Convert.ToInt32(inputCustomerID);
                newOrder.CustomerSurname = inputProductName;
                newOrder.CustomerHouseNo = inputHouseNumber;
                newOrder.CustomerStreetName = inputAddress;
                newOrder.CustomerPostCode = inputPostCode;
                newOrder.CustomerTown = inputCity;
                newOrder.CustomerPostCode = inputPostCode;
                newOrder.ProductID = Convert.ToInt32(inputProductID);
                newOrder.ProductName = inputProductName;
                newOrder.ProductQty = Convert.ToInt32(inputQuantity);
                newOrder.OrderCost = Convert.ToDecimal(inputCost);
                newOrder.OrderShippingCost = Convert.ToDecimal(inputShippingCost);
                newOrder.OrderFinalTotal = Convert.ToDecimal(inputFinalTotal);
                newOrder.OrderStatus = inputStatus;

                context.tblOrders.Add(newOrder);
                context.SaveChanges();

                this.Close();
            }
        }

        private void Add_Order_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_OrderCustomerID.Text = string.Empty;
            Add_OrderCustomerSurname.Text = string.Empty;
            Add_OrderHouseNumber.Text = string.Empty;
            Add_OrderAddress.Text = string.Empty;
            Add_OrderPostCode.Text = string.Empty;
            Add_OrderCity.Text = string.Empty;
            Add_OrderCountry.Text = string.Empty;
            Add_OrderProductID.Text = string.Empty;
            Add_OrderProductName.Text = string.Empty;
            Add_OrderQuantity.Text = string.Empty;
            Add_OrderCost.Text = string.Empty;
            Add_OrderShippingCost.Text = string.Empty;
            Add_OrderFinalTotal.Text = string.Empty;
            Add_OrderStatus.Text = string.Empty;
        }
    }
}
