using SE1726_Group6_A1.Models;
using System.Windows;

namespace SE1726_Group6_A1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Staff user { get; set; }
        public MainWindow()
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

        private void btnViewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow profile = new ProductWindow();
            this.Hide();
            profile.Show();
        }

        private void btnStaffView_Click(object sender, RoutedEventArgs e)
        {
            AdminStaff profile = new AdminStaff()
            {
                user = user,
            };
            this.Hide();
            profile.Show();
        }


        private void btnReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}