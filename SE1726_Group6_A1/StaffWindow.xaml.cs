using SE1726_Group6_A1.Models;
using System.Windows;

namespace SE1726_Group6_A1
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public Staff user { get; set; }
        public StaffWindow()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile()
            {
                user = user,
            };
            this.Hide();
            profile.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderView_Click(object sender, RoutedEventArgs e)
        {
            OrderManager orderManager = new OrderManager()
            {
                user = user,
            };
            this.Hide();
            orderManager.Show();
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
