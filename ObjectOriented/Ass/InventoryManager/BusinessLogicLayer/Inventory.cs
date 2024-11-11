using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager{
    // Lớp Inventory
    public class Inventory{
        private readonly InventoryRepository _inventoryRepository; // thêm biến để lưu InventoryRepository

        // Constructor nhan tham so InventoryRepository
        public Inventory(InventoryRepository inventoryRepository){
            _inventoryRepository = inventoryRepository;
        }
        // Thêm sản phẩm
        public void AddProduct(Product product){
            if (product == null){
                Console.WriteLine("Product cannot be null.");
                return;
            }
            _inventoryRepository.Add(product);
            Console.WriteLine("Add product successfully");
        }

        // Cập nhật thông tin sản phẩm
        public void UpdateProduct(int productId, string productName, double price, int quantity){
            Product pt = _inventoryRepository.FindProduct(productId);
            if (pt != null){
                pt.ProductName = productName;
                pt.Price = price;
                pt.Quantity = quantity;
                _inventoryRepository.Update(pt);
                Console.WriteLine("Update product successfully");
            }else{
                Console.WriteLine("Product not found");
            }
        }
        // Xóa sản phẩm
        public void DeleteProduct(int productId){
            Product pt = FindProduct(productId);
            if (pt != null){
                _inventoryRepository.Delete(productId);
                Console.WriteLine("Delete product successfully");
            }else {
                Console.WriteLine("Product not found");
            }
        }
         // Hiển thị danh sách sản phẩm
        public void Display()
        {
            var products = _inventoryRepository.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                var sortedProducts = products.OrderBy(p => p.ProductId);
                foreach (var product in sortedProducts)
                {
                    product.Display();
                }
            }
        }
        // Tìm sản phẩm theo mã sản phẩm
        public Product FindProduct(int productId){
            return _inventoryRepository.FindProduct(productId);
        }
        // Tìm sản phẩm theo tên sản phẩm
        public List<Product> SearchProduct(string productName){
            return _inventoryRepository.GetAllProducts()
                .FindAll(product => product.ProductName.IndexOf(productName, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        // Tìm sản phẩm theo giá
        public List<Product> SearchProductPrice(double price){
            return _inventoryRepository.GetAllProducts()
                .FindAll(product => product.Price == price);
        }
        // Lấy danh sách sản phẩm có số lượng tồn kho thấp
        public List<Product> GetLowStockProducts(int threshold){
            return _inventoryRepository.GetLowStockProducts(threshold);
        }
    }
}