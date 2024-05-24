using SE1726_Group6_A1.Models;
using System.Windows;

namespace SE1726_Group6_A1
{

    public partial class ProductWindow : Window
    {
        MyStoreContext context;
        public ProductWindow()
        {
            InitializeComponent();
            context = new MyStoreContext();

            Product product1 = new Product
            {
                ProductId = 1,
                ProductName = "Test1",
                CategoryId = 1,
                UnitPrice = 1,

            };
            context.Products.Add(product1);
            Product product2 = new Product
            {
                ProductId = 2,
                ProductName = "Test2",
                CategoryId = 2,
                UnitPrice = 2,

            };
            context.Products.Add(product2);
            context.SaveChanges();
            lsProduct.ItemsSource = context.Products.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductId.Text);
                if (context.Products.Any(p => p.ProductId == productId))
                {
                    MessageBox.Show("Product with the same ID already exists!");
                    return;
                }
                Product Product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = int.Parse(txtCategoryId.Text),
                    UnitPrice = int.Parse(txtUnitPrice.Text),
                };

                context.Products.Add(Product);
                context.SaveChanges();
                MessageBox.Show("Added!");
                lsProduct.ItemsSource = context.Products.OrderBy(x => x.ProductId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lsProduct.SelectedItem == null) return;
            int ProductId = int.Parse(txtProductId.Text);
            Product Product = context.Products.Find(ProductId);
            Product.ProductName = txtProductName.Text;
            Product.CategoryId = int.Parse(txtCategoryId.Text);
            Product.UnitPrice = int.Parse(txtUnitPrice.Text);
            try
            {
                context.Products.Update(Product);
                context.SaveChanges();
                MessageBox.Show("Updated!");
                lsProduct.ItemsSource = context.Products.OrderBy(x => x.ProductId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsProduct.SelectedItem == null) return;
            int ProductId = int.Parse(txtProductId.Text);
            Product Product = context.Products.Find(ProductId);
            try
            {

                context.Products.Remove(Product);
                context.SaveChanges();
                MessageBox.Show("Deleted!");
                lsProduct.ItemsSource = context.Products.OrderBy(x => x.ProductId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchProductName = txtSearchProductName.Text.Trim();
            string searchUnitPriceText = txtSearchUnitPrice.Text.Trim();

            decimal searchUnitPrice;
            bool isUnitPriceValid = decimal.TryParse(searchUnitPriceText, out searchUnitPrice);

            var filteredProducts = context.Products.Where(p =>
                (string.IsNullOrEmpty(searchProductName) || p.ProductName.Contains(searchProductName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(searchUnitPriceText) || (isUnitPriceValid && p.UnitPrice == searchUnitPrice))
            ).ToList();

            lsProduct.ItemsSource = filteredProducts;
        }
    }

}
