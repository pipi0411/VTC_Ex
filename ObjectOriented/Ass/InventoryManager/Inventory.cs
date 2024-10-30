using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager{
    // Lớp Inventory
    public class Inventory{
        private List<Product> listProducts = new List<Product>();
        // Thêm sản phẩm
        public void AddProduct(Product product){
            if (product == null){
                Console.WriteLine("Product cannot be null.");
                return;
            }
            listProducts.Add(product);
            Console.WriteLine("Add product successfully");
        }

        // Cập nhật thông tin sản phẩm
        public void UpdateProduct(int productId, string productName, double price, int quantity){
            Product pt = FindProduct(productId);
            if (pt != null){
                pt.ProductName = productName;
                pt.Price = price;
                pt.Quantity = quantity;
                Console.WriteLine("Update product successfully");
            }else{
                Console.WriteLine("Product not found");
            }
        }
        // Xóa sản phẩm
        public void DeleteProduct(int productId){
            Product pt = FindProduct(productId);
            if (pt != null){
                listProducts.Remove(pt);
                Console.WriteLine("Delete product successfully");
            }else {
                Console.WriteLine("Product not found");
            }
        }
        // Hiển thị danh sách sản phẩm
        public void Display(){
            if (listProducts.Count == 0){
                Console.WriteLine("No products available.");
            }else {
                foreach (var product in listProducts){
                    product.Display();
                }
            }
        }
        // Tìm sản phẩm theo mã sản phẩm
        public Product FindProduct(int productId){
            return listProducts.FirstOrDefault(product => product.ProductId == productId);
        }
        // Tìm sản phẩm theo tên sản phẩm
        public List<Product> SearchProduct(string productName){
            return listProducts.Where(product => product.ProductName.IndexOf(productName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        // Lấy danh sách sản phẩm có số lượng tồn kho thấp
        public List<Product> GetLowStockProducts(int threshold){
            return listProducts.Where(product => product.Quantity < threshold).ToList();
        }
    }
}