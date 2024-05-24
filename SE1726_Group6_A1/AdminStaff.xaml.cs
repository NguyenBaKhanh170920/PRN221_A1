using SE1726_Group6_A1.Models;
using System.Windows;
using System.Windows.Controls;

namespace SE1726_Group6_A1
{
    /// <summary>
    /// Interaction logic for AdminStaff.xaml
    /// </summary>
    public partial class AdminStaff : Window
    {
        private readonly MyStoreContext context;
        public List<Staff> AllStaff;
        public Staff user { get; set; }
        public AdminStaff()
        {
            InitializeComponent();
            this.DataContext = this;
            context = new MyStoreContext();
            LoadAllStaff();
        }
        public void LoadAllStaff()
        {
            using (var db = new MyStoreContext())
            {
                AllStaff = db.Staffs.ToList();
                lvStaff.ItemsSource = AllStaff;
            }
        }

        private void txtStaffId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffName.Text))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            Staff staff = new Staff
            {
                Name = txtStaffName.Text,
                Password = txtPassword.Text,
                Role = int.Parse(txtRole.Text)
            };

            context.Staffs.Add(staff);
            context.SaveChanges();
            LoadAllStaff();
            MessageBox.Show("Staff added successfully");
            txtStaffName.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffName.Text))
            {
                MessageBox.Show("Name can't empty");
                return;
            }
            try
            {
                Staff staff = context.Staffs.FirstOrDefault(x => x.StaffId == int.Parse(txtStaffId.Text));
                if (staff != null)
                {
                    staff.Name = txtStaffName.Text;
                    staff.Password = txtPassword.Text;
                    staff.Role = int.Parse(txtRole.Text);
                    context.Staffs.Update(staff);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update successful");
                        LoadAllStaff();
                        // Select the updated staff in the ListView
                        lvStaff.SelectedItem = staff;
                    }
                }
                else
                {
                    MessageBox.Show("Do not change ID of staff");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the staff: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffId.Text))
            {
                MessageBox.Show("Invalid staff ID");
                return;
            }
            try
            {
                Staff staff = context.Staffs.FirstOrDefault(x => x.StaffId == int.Parse(txtStaffId.Text));
                if (staff != null)
                {
                    context.Staffs.Remove(staff);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Staff deleted successfully");
                    }
                    LoadAllStaff();
                }
                else
                {
                    MessageBox.Show("Staff does not exist");
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Invalid staff ID");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearchStaff.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a staff name to search for.");
                return;
            }

            List<Staff> list = context.Staffs
                    .Where(x => x.Name.IndexOf(searchText) >= 0)
                    .ToList();

            if (list.Count > 0)
            {
                lvStaff.ItemsSource = list;
            }
            else
            {
                MessageBox.Show("No staff found.");
            }
        }

        private void lvStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvStaff.SelectedItem is Staff selectedStaff)
            {
                txtStaffId.Text = selectedStaff.StaffId.ToString();
                txtStaffName.Text = selectedStaff.Name;
                txtPassword.Text = selectedStaff.Password;
                txtRole.Text = selectedStaff.Role.ToString();
            }
        }

        private void txtStaffName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRole_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSearchStaff_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                user = user,
            };
            this.Hide();
            mainWindow.Show();
        }
    }
}
