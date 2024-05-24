using SE1726_Group6_A1.Models;
using System.Windows;

namespace SE1726_Group6_A1
{
    public partial class Profile : Window
    {
        public Staff user { get; set; }
        MyStoreContext _context;
        public Profile()
        {
            InitializeComponent();
            _context = new MyStoreContext();
            Loaded += MainWindow_Loaded;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (user.StaffId == 1)
            {
                MainWindow mainWindow = new MainWindow()
                {
                    user = user,
                };
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                StaffWindow mainWindow = new StaffWindow()
                {
                    user = user,
                };
                this.Hide();
                mainWindow.Show();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Name = txtName.Text;
                user.Password = txtPass.Text;
                user.Role = int.Parse(txtRole.Text);
                _context.Staffs.Update(user);
                _context.SaveChanges();
                MessageBox.Show("Update completed ");
                Load(user);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Load(Staff user)
        {
            txtId.Text = user.StaffId.ToString();
            txtName.Text = user.Name;
            txtPass.Text = user.Password;
            txtRole.Text = user.Role.ToString();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load data into the TextBox when the window is loaded
            Load(user);
        }
    }
}
