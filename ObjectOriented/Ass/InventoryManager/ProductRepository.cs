using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace InventoryManager{
    // Lớp ProductRepository
    public class ProductRepository{
        // Đường dẫn file lưu trữ thông tin sản phẩm
        private readonly string _filePath;
        public ProductRepository(string filePath){
            _filePath = filePath;
            if (!File.Exists(_filePath)){
                File.Create(_filePath).Dispose(); // Tạo file mới nếu chưa tồn tại
            }
        }
        // Lấy danh sách sản phẩm từ file
        public List<Product> GetAllProducts(){
            var products = new List<Product>();
            foreach (var line in File.ReadAllLines(_filePath)){
                var data = line.Split(',');
                if(data.Length == 4  && 
                int.TryParse(data[0], out int productId) &&
                double.TryParse(data[2], out double price) &&
                int.TryParse(data[3], out int quantity))
                {
                    products.Add(new Product(productId, data[1], price, quantity));
                }
            }
            return products;
        }
        // Thêm sản phẩm vào file
        public void AddProduct(Product product){
            var products = GetAllProducts();
            if(products.Any(p => p.ProductId == product.ProductId)){
                Console.WriteLine("Product already exists");
                return;
            }
            using (var sw = File.AppendText(_filePath)){
                sw.WriteLine($"{product.ProductId},{product.ProductName},{product.Price},{product.Quantity}");
            }
            Console.WriteLine("Product added successfully");
        }
        // Xóa sản phẩm khỏi file
        public void RemoveProduct(int productId){
            var products = GetAllProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if(product == null){
                Console.WriteLine("Product not found");
                return;
            }
            products.Remove(product);
            SaveAllProducts(products);
            Console.WriteLine("Product removed successfully");
        }
        // Cập nhật thông tin sản phẩm
        public void UpdateProduct(Product product){
            var products = GetAllProducts();
            var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if(existingProduct == null){
                Console.WriteLine("Product not found");
                return;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            SaveAllProducts(products);
            Console.WriteLine("Product updated successfully");
        }
        // Lưu danh sách sản phẩm vào file
        private void SaveAllProducts(List<Product> products){
            using (var sw = new StreamWriter(_filePath)){
                foreach (var product in products){
                    sw.WriteLine($"{product.ProductId},{product.ProductName},{product.Price},{product.Quantity}");
                }
            }
        }
    }
}