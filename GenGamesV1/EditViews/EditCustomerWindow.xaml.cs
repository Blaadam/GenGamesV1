using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private int SelectedCustomerID;
        public EditCustomerWindow(int CategoryID)
        {
            InitializeComponent();
            SelectedCustomerID = CategoryID;

            Edit_LabelID.Content = "Customer ID: " + SelectedCustomerID.ToString();

            var context = new GenericGamesWPFEntities();
            // Retrieve category data from the database and set it as the source for the CollectionViewSource
            var Row = context.tblCustomers.Where(c => c.CustomerID == SelectedCustomerID).FirstOrDefault();
            Edit_CustomerFirstNameTb.Text = Row.CustomerFirstName;
            Edit_CustomerSurnameNameTb.Text = Row.CustomerSurname;
            Edit_CustomerHomeNumberTb.Text = Row.CustomerHouseNo;
            Edit_CustomerStreetNameTb.Text = Row.CustomerAddressStreetName;
            Edit_CustomerCityTb.Text = Row.CustomerCity;
            Edit_CustomerCountyTb.Text = Row.CustomerCountry;
            Edit_CustomerPostCodeTb.Text = Row.CustomerPostcode;
            Edit_CustomerHomeTelTb.Text = Row.CustomerHomeTel.ToString();
            Edit_CustomerMobileTb.Text = Row.CustomerMobile.ToString();
        }

        private void Edit_Category_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GenericGamesWPFEntities())
            {
                string inputFirstName = Edit_CustomerFirstNameTb.Text.Trim();
                string inputSurname = Edit_CustomerSurnameNameTb.Text.Trim();
                string inputHouseNumber = Edit_CustomerHomeNumberTb.Text.Trim();
                string inputStreetName = Edit_CustomerStreetNameTb.Text.Trim();
                string inputPostCode = Edit_CustomerPostCodeTb.Text.Trim();
                string inputCity = Edit_CustomerCityTb.Text.Trim();
                string inputCountry = Edit_CustomerCountyTb.Text.Trim();
                string inputHomeTel = Edit_CustomerHomeTelTb.Text.Trim();
                string inputMobileNo = Edit_CustomerMobileTb.Text.Trim();

                var editCustomer = context.tblCustomers.Where(c => c.CustomerID == SelectedCustomerID).FirstOrDefault();
                editCustomer.CustomerFirstName = inputFirstName;
                editCustomer.CustomerSurname = inputSurname;
                editCustomer.CustomerHouseNo = inputHouseNumber;
                editCustomer.CustomerAddressStreetName = inputStreetName;
                editCustomer.CustomerPostcode = inputPostCode;
                editCustomer.CustomerCity = inputCity;
                editCustomer.CustomerCountry = inputCountry;
                editCustomer.CustomerHomeTel = Convert.ToInt32(inputHomeTel);
                editCustomer.CustomerMobile = Convert.ToInt32(inputMobileNo);

                context.SaveChanges();

                MessageBox.Show("This Customer has been Edited!", "Generic Games v1.0 Edit Customer", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }

        private void Edit_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_CustomerFirstNameTb.Clear();
            Edit_CustomerSurnameNameTb.Clear();
            Edit_CustomerHomeNumberTb.Clear();
            Edit_CustomerStreetNameTb.Clear();
            Edit_CustomerCityTb.Clear();
            Edit_CustomerCountyTb.Clear();
            Edit_CustomerPostCodeTb.Clear();
            Edit_CustomerHomeTelTb.Clear();
            Edit_CustomerMobileTb.Clear();
        }
    }
}
