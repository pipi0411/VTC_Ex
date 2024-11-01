using System;
namespace InventoryManager{
    public class InventoryApp{
        // Lưu trữ thể hiện của Inventory để quản lý sản phẩm.
        private readonly Inventory _inventory; // Thêm biến lưu Inventory
        private readonly InventoryRepository _inventoryReponsitory; // Thêm biến lưu InventoryRepository

         // Constructor để khởi tạo InventoryApp với một thể hiện Inventory.
        public InventoryApp(Inventory inventory, InventoryRepository inventoryReponsitory){
            _inventory = inventory;
            _inventoryReponsitory = inventoryReponsitory;
        }
       // Vòng lặp chính để chạy ứng dụng quản lý kho.
        public void Run(){
            while(true){
                DisplayMenu();  // Hiển thị các tùy chọn cho người dùng.
                var choice = Console.ReadLine(); // Đọc đầu vào của người dùng cho lựa chọn menu.
                // Câu lệnh switch để xử lý lựa chọn của người dùng.
                switch(choice){
                    case "1":
                        AddProduct(); // Thêm sản phẩm.
                        break;
                    case "2":
                        UpdateProduct(); // Cập nhật thông tin sản phẩm.
                        break;
                    case "3":
                        DeleteProduct(); // Xóa sản phẩm.
                        break;
                    case "4":
                        DisplayInventory(); // Hiển thị danh sách sản phẩm trong kho.
                        break;
                    case "5":
                        SearchProduct(); // Tìm kiếm sản phẩm theo tên.
                        break;
                    case "6":
                        CheckLowStock(); // Kiểm tra các sản phẩm dưới ngưỡng tồn kho.
                        break;
                    case "7":
                        CreateOrder(); // Tạo một đơn hàng mới cho một sản phẩm.
                        break;
                    case "0":
                        Console.WriteLine("Exiting..."); // Thoát ứng dụng.
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again."); // Xử lý đầu vào không hợp lệ.
                        break;
                }
            }
        }
        // Hiển thị menu chính cho người dùng.
        private void DisplayMenu(){
            Console.WriteLine("---Inventory Management System---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Display Inventory");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. Check Low Stock");
            Console.WriteLine("7. Create Order");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
        }

        // Thêm sản phẩm vào kho.
        private void AddProduct(){
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine()); // Đọc mã sản phẩm từ bàn phím.
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine(); // Đọc tên sản phẩm từ bàn phím.
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine()); // Đọc giá sản phẩm từ bàn phím.
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine()); // Đọc số lượng sản phẩm từ bàn phím.
            // Tạo một thể hiện mới của Product với thông tin vừa nhập.
            var product = new Product(productId, productName, price, quantity);
            _inventory.AddProduct(product); // Thêm sản phẩm vào kho.
        }

        // Cập nhật thông tin sản phẩm trong kho.
        private void UpdateProduct(){
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine()); // Đọc mã sản phẩm từ bàn phím.
            Console.Write("Enter New Product Name: ");
            string productName = Console.ReadLine(); // Đọc tên sản phẩm từ bàn phím.
            Console.Write("Enter New Price: ");
            double price = double.Parse(Console.ReadLine()); // Đọc giá sản phẩm từ bàn phím.
            Console.Write("Enter New Quantity: ");
            int quantity = int.Parse(Console.ReadLine()); // Đọc số lượng sản phẩm từ bàn phím.
            
            _inventory.UpdateProduct(productId, productName, price, quantity); // Cập nhật thông tin sản phẩm.
        }
        
        // Xóa sản phẩm khỏi kho.
        private void DeleteProduct(){
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine()); // Đọc mã sản phẩm từ bàn phím.
            _inventory.DeleteProduct(productId); // Xóa sản phẩm khỏi kho.
        }

        // Hiển thị danh sách sản phẩm trong kho.
        private void DisplayInventory(){
            _inventory.Display(); // Hiển thị danh sách sản phẩm trong kho.
        }
        // Tìm kiếm sản phẩm theo tên.
        private void SearchProduct(){
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine(); // Đọc tên sản phẩm từ bàn phím.
            var products = _inventory.SearchProduct(productName); // Tìm kiếm sản phẩm theo tên.
            // Hiển thị thông tin sản phẩm nếu tìm thấy.
            if (products.Count > 0){
                foreach (var product in products){
                    product.Display();
                }
            }else {
                Console.WriteLine("Product not found");
            }
        }

        // Kiểm tra các sản phẩm dưới ngưỡng tồn kho.
        private void CheckLowStock(){
            Console.Write("Enter Stock Threshold: ");
            int threshold = int.Parse(Console.ReadLine()); // Đọc ngưỡng tồn kho từ bàn phím.
            var lowStockProducts = _inventory.GetLowStockProducts(threshold); // Lấy danh sách sản phẩm dưới ngưỡng tồn kho.

            if (lowStockProducts.Count > 0){
                Console.WriteLine("Products with low stock:");
                foreach (var product in lowStockProducts){
                    product.Display();
                }
            }else {
                Console.WriteLine("No products with low stock");
            } 
        }
        // Tạo một đơn hàng mới cho một sản phẩm.
        private void CreateOrder(){
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine()); // Đọc mã sản phẩm từ bàn phím.
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine()); // Đọc số lượng sản phẩm từ bàn phím.
            var product = _inventory.FindProduct(productId); // Tìm sản phẩm theo mã sản phẩm.
            if (product == null){
                Console.WriteLine("Product not found");
                return;
            }
            var order = new Order(_inventoryReponsitory); // Khởi tạo với InventoryRepository
            bool orderCreated = order.CreadOrder(product, quantity);
            if (orderCreated)
            {
                Console.WriteLine($"Order created successfully. {quantity} of {product.ProductName} ordered."); // Hiển thị thông báo đơn hàng đã được tạo.
            }
            else
            {
                Console.WriteLine("Order failed. Please try again."); // Hiển thị thông báo lỗi nếu đơn hàng không được tạo.
            }
        }
    }
}