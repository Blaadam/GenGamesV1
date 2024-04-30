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
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void Add_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_CustomerFirstNameTb.Text = string.Empty;
            Add_CustomerSurnameNameTb.Text = string.Empty;
            Add_CustomerHomeNumberTb.Text = string.Empty;
            Add_CustomerStreetNameTb.Text = string.Empty;
            Add_CustomerPostCodeTb.Text = string.Empty;
            Add_CustomerCityTb.Text = string.Empty;
            Add_CustomerCountyTb.Text = string.Empty;
            Add_CustomerHomeTelTb.Text = string.Empty;
            Add_CustomerMobileTb.Text = string.Empty;
        }

        private void Add_Category_AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GenericGamesWPFEntities())
            {
                string inputFirstName = Add_CustomerFirstNameTb.Text.Trim();
                string inputSurname = Add_CustomerSurnameNameTb.Text.Trim();
                string inputHouseNumber = Add_CustomerHomeNumberTb.Text.Trim();
                string inputStreetName = Add_CustomerStreetNameTb.Text.Trim();
                string inputPostCode = Add_CustomerPostCodeTb.Text.Trim();
                string inputCity = Add_CustomerCityTb.Text.Trim();
                string inputCountry = Add_CustomerCountyTb.Text.Trim();
                string inputHomeTel = Add_CustomerHomeTelTb.Text.Trim();
                string inputMobileNo = Add_CustomerMobileTb.Text.Trim();

                if (string.IsNullOrEmpty(inputFirstName) || string.IsNullOrEmpty(inputSurname) || string.IsNullOrEmpty(inputHouseNumber) || string.IsNullOrEmpty(inputStreetName) || string.IsNullOrEmpty(inputPostCode) || string.IsNullOrEmpty(inputCity) || string.IsNullOrEmpty(inputCountry) || string.IsNullOrEmpty(inputHomeTel) || string.IsNullOrEmpty(inputMobileNo) || string.IsNullOrEmpty(inputStreetName) )
                {
                    MessageBox.Show("One or more field(s) are empty.", "Generic Games v1.0 Add Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectedCategory = (from user in context.tblCustomers
                                        where user.CustomerFirstName == inputFirstName && user.CustomerSurname == inputSurname && user.CustomerAddressStreetName == inputStreetName
                                        select user).FirstOrDefault();

                if (selectedCategory != null)
                {
                    MessageBox.Show("This Customer already Exists.", "Generic Games v1.0 Add Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                tblCustomer newCustomer = new tblCustomer();
                newCustomer.CustomerFirstName = inputFirstName;
                newCustomer.CustomerSurname = inputSurname;
                newCustomer.CustomerHouseNo = inputHouseNumber;
                newCustomer.CustomerAddressStreetName = inputStreetName;
                newCustomer.CustomerPostcode = inputPostCode;
                newCustomer.CustomerCity = inputCity;
                newCustomer.CustomerCountry = inputCountry;
                newCustomer.CustomerHomeTel = Convert.ToInt32(inputHomeTel);
                newCustomer.CustomerMobile = Convert.ToInt32(inputMobileNo);

                context.tblCustomers.Add(newCustomer);
                context.SaveChanges();

                MessageBox.Show($"Customer \"{inputFirstName + " " + inputSurname}\" has been created.", "Generic Games v1.0 Add Customer", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
        }
    }
}
