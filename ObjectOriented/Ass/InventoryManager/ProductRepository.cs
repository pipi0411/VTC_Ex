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
                int.TryParse(data[0], out int id) &&
                double.TryParse(data[2], out double price) &&
                int.TryParse(data[3], out int quantity))
                {
                    products.Add(new Product{
                        ProductId = id,
                        ProductName = data[1],
                        Price = price,
                        Quantity = quantity
                    });
                }
            }
            return products;
        }
    }
}