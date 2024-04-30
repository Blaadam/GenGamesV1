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

namespace GenGamesV1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            UsernameTb.Text = string.Empty;
            PasswordTb.Password = string.Empty;

            UsernameTb.Focus();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Establish a connection to the database
            using (var context = new GenericGamesWPFEntities())
            {
                // Retrieve input username and password
                string inputUsername = UsernameTb.Text;
                string inputPassword = PasswordTb.Password;

                // Query the database for the user with the provided username
                var selectedUser = (from user in context.tblUsers
                                    where user.UserName == inputUsername
                                    select user).FirstOrDefault();

                // Check if the user exists
                if (selectedUser == null)
                {
                    // Display error message for incorrect credentials
                    MessageBox.Show("Incorrect login credentials - Please try again!", "Generic Games v1.0.0.0 - Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Check if the password matches
                else if (selectedUser.Password == inputPassword)
                {
                    // Display welcome message
                    MessageBox.Show($"Welcome, {inputUsername}", "Generic Games v1.0.0.0 - Notification", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Open the main window
                    MainWindow window = new MainWindow();
                    this.Close();
                    window.ShowDialog();
                }
                else
                {
                    // Display error message for incorrect credentials
                    MessageBox.Show("Incorrect login credentials - Please try again!", "Generic Games v1.0.0.0 - Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Display information about account creation process
            MessageBox.Show("To create an account, contact the IT department and request access.", "Generic Games v1.0 - Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
