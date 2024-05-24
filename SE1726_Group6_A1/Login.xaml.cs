using SE1726_Group6_A1.Models;
using System.Windows;

namespace SE1726_Group6_A1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MyStoreContext _context;

        Staff user;
        public Login()
        {
            InitializeComponent();
            _context = new MyStoreContext();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string password = txtPassword.Password.ToString();
                string adminName = App.Configuration["Staff:Name"];
                string adminPassword = App.Configuration["Staff:Password"];
                var login = _context.Staffs.FirstOrDefault(s => s.Name == name);
                if (name == adminName && password == adminPassword)
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow()
                    {
                        user = login
                    };
                    mainWindow.Show();
                }
                else
                {
                    if (login != null)
                    {
                        if (login.Password == password)
                        {
                            this.Hide();
                            StaffWindow staffWindow = new StaffWindow()
                            {
                                user = login
                            };
                            staffWindow.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wrong password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
