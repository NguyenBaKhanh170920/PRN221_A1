using SE1726_Group6_A1.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SE1726_Group6_A1
{
    /// <summary>
    /// Interaction logic for OrderManager.xaml
    /// </summary>
    public partial class OrderManager : Window
    {
        MyStoreContext context = new MyStoreContext();
        List<Order> orders = new List<Order>();
        public Staff user { get; set; }
        public OrderManager()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            lvOrder.ItemsSource = context.Orders.ToList();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            orderID.Text = string.Empty;
            staffId.Text = string.Empty;
            dobDate.SelectedDate = DateTime.Now;
            MessageBox.Show("F5 success");
            loadData();
        }

        private Order GetOrderObject()
        {
            Order orders = null;
            try
            {
                orders = new Order
                {
                    OrderId = string.IsNullOrEmpty(orderID.Text)
                        ? 0
                        : int.Parse(orderID.Text),

                    OrderDate = dobDate.SelectedDate != null ? dobDate.SelectedDate.Value : DateTime.Now,
                    StaffId = int.Parse(staffId.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get employee");
            }
            return orders;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now, // Đặt ngày đơn hàng là ngày hiện tại
                StaffId = user.StaffId // Thay bằng StaffId tương ứng
            };

            // Thêm đơn hàng mới vào cơ sở dữ liệu
            context.Orders.Add(newOrder);
            context.SaveChanges();
            MessageBox.Show("Add success");
            // Reload dữ liệu trên ListView
            loadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Order neworder = GetOrderObject();

            if (neworder != null)
            {
                var oldObj = context.Orders.FirstOrDefault(x => x.OrderId == neworder.OrderId);
                if (oldObj != null)
                {
                    oldObj.OrderDate = neworder.OrderDate;
                    oldObj.StaffId = neworder.StaffId;

                    context.SaveChanges();
                    loadData();
                    MessageBox.Show($"{neworder.OrderId} updated successfully", "Update Order");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem != null) // Kiểm tra xem đã chọn một đơn hàng
            {
                Order selectedOrder = lvOrder.SelectedItem as Order;

                // Xóa đơn hàng đã chọn từ cơ sở dữ liệu
                context.Orders.Remove(selectedOrder);
                context.SaveChanges();
                MessageBox.Show("Delete success");
                // Reload dữ liệu trên ListView
                loadData();
            }
        }



        private void lvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOrder.SelectedItem != null)
            {
                Order selectedOrder = lvOrder.SelectedItem as Order;

                if (selectedOrder != null)
                {
                    orderID.Text = selectedOrder.OrderId.ToString();
                    staffId.Text = selectedOrder.StaffId.ToString();
                    dobDate.SelectedDate = selectedOrder.OrderDate;

                    // Load OrderDetails tương ứng với Order đó
                    var orderDetails = context.OrderDetails.Where(od => od.OrderId == selectedOrder.OrderId).ToList();
                    lvOrderDetail.ItemsSource = orderDetails;

                    if (orderDetails.Count > 0)
                    {
                        // Hiển thị thông tin chi tiết đầu tiên trong ListView OrderDetail
                        lvOrderDetail.SelectedItem = orderDetails[0];
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime searchDate = dobDate.SelectedDate ?? DateTime.Today; // Lấy ngày tìm kiếm từ DatePicker, nếu không có thì mặc định là ngày hiện tại

            // Tìm kiếm đơn hàng theo OrderDate
            var result = context.Orders.Where(o => o.OrderDate.Date == searchDate.Date).ToList();

            if (result.Count > 0)
            {
                lvOrder.ItemsSource = result;
                MessageBox.Show("Search completed.", "Search Order");
            }
            else
            {
                MessageBox.Show("No orders found for the specified date.", "Search Order");
            }
        }


        private void loadDataDetail()
        {
            //// Xóa dữ liệu cũ trên ListView OrderDetail trước khi tải dữ liệu mới
            //lvOrderDetail.Items.Clear();

            //// Lấy danh sách chi tiết đơn hàng từ cơ sở dữ liệu
            //var orderDetails = context.OrderDetails.ToList();

            //// Hiển thị danh sách chi tiết đơn hàng lên ListView OrderDetail
            //foreach (var detail in orderDetails)
            //{
            //    lvOrderDetail.Items.Add(detail);
            //}
            lvOrderDetail.ItemsSource = context.OrderDetails.ToList();
        }

        private void btnRefreshDetail_Click(object sender, RoutedEventArgs e)
        {
            detailID.Text = string.Empty;
            orderDetailID.Text = string.Empty;
            productID.Text = string.Empty;
            unitPrice.Text = string.Empty;
            quantity.Text = string.Empty;
            MessageBox.Show("Refreshed Order Detail");
        }

        private void btnInsertDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail newDetail = new OrderDetail
                {
                    OrderId = int.Parse(orderDetailID.Text),
                    ProductId = int.Parse(productID.Text),
                    UnitPrice = (int)Math.Round(decimal.Parse(unitPrice.Text)),
                    Quantity = int.Parse(quantity.Text)
                };

                context.OrderDetails.Add(newDetail);
                context.SaveChanges();

                MessageBox.Show("New Order Detail added successfully.", "Insert Order Detail");

                // Load chỉ chi tiết của Order mới thêm vào ListView OrderDetail
                var orderDetailsForNewOrder = context.OrderDetails.Where(od => od.OrderId == newDetail.OrderId).ToList();
                lvOrderDetail.ItemsSource = orderDetailsForNewOrder;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please ensure that all fields are filled correctly with appropriate data types.", "Error Inserting Order Detail");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting Order Detail: {ex.Message}", "Error Inserting Order Detail");
            }
        }

        private void btnUpdateDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvOrderDetail.SelectedItem != null)
                {
                    OrderDetail selectedDetail = lvOrderDetail.SelectedItem as OrderDetail;

                    if (selectedDetail != null)
                    {
                        // Lấy thông tin mới từ người dùng
                        selectedDetail.ProductId = int.Parse(productID.Text);
                        selectedDetail.UnitPrice = (int)Math.Round(decimal.Parse(unitPrice.Text));
                        selectedDetail.Quantity = int.Parse(quantity.Text);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        context.SaveChanges();

                        MessageBox.Show("Order Detail updated successfully.", "Update Order Detail");

                        // Cập nhật chỉ mục của phần tử đã thay đổi trong ListView
                        lvOrderDetail.Items.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an Order Detail to update.", "Update Error");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please ensure that all fields are filled correctly with appropriate data types.", "Error Updating Order Detail");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Order Detail: {ex.Message}", "Error Updating Order Detail");
            }
        }

        private void btnDeleteDetail_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrderDetail.SelectedItem != null)
            {
                OrderDetail selectedDetail = lvOrderDetail.SelectedItem as OrderDetail;

                if (selectedDetail != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Order Detail?", "Confirm Delete", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            // Xóa Order Detail từ cơ sở dữ liệu
                            context.OrderDetails.Remove(selectedDetail);
                            context.SaveChanges();

                            // Cập nhật ListView
                            var orderDetails = lvOrderDetail.ItemsSource as List<OrderDetail>;
                            if (orderDetails != null)
                            {
                                orderDetails.Remove(selectedDetail);

                                // Tạo một ObservableCollection mới từ List đã được cập nhật
                                ObservableCollection<OrderDetail> updatedOrderDetails = new ObservableCollection<OrderDetail>(orderDetails);
                                lvOrderDetail.ItemsSource = updatedOrderDetails;

                                MessageBox.Show("Order Detail deleted successfully.", "Delete Order Detail");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting Order Detail: {ex.Message}", "Delete Order Detail Error");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an Order Detail to delete.", "Delete Order Detail Error");
            }
        }

        private void lvOrderDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOrderDetail.SelectedItem != null)
            {
                OrderDetail selectedDetail = lvOrderDetail.SelectedItem as OrderDetail;

                if (selectedDetail != null)
                {
                    // Hiển thị thông tin chi tiết đơn hàng trong các TextBox tương ứng
                    detailID.Text = selectedDetail.OrderDetailId.ToString();
                    orderDetailID.Text = selectedDetail.OrderId.ToString();
                    productID.Text = selectedDetail.ProductId.ToString();
                    unitPrice.Text = selectedDetail.UnitPrice.ToString();
                    quantity.Text = selectedDetail.Quantity.ToString();
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            StaffWindow staffWindow = new StaffWindow()
            {
                user = user
            };
            this.Close();
            staffWindow.Show();
        }

        //private void btnListOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    ListOrder listOrder = new ListOrder();
        //    listOrder.Show();
        //}
    }
}

