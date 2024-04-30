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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenGamesV1.Pages.CustomerPages
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        public CustomerView()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            var context = new GenericGamesWPFEntities();
            CustomerDg.ItemsSource = context.tblCustomers.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
