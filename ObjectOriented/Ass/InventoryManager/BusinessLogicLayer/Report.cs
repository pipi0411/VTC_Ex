using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager{
    // Lớp Report
    public class Report{
        // Tạo báo cáo tồn kho
        public void GenerateInventoryReport(List<Product> listProducts){
            if (listProducts.Count == 0){
                Console.WriteLine("No products available.");
            }else {
                Console.WriteLine("---Inventory Report---");
                Console.WriteLine("Product ID\tProduct Name\tPrice\tQuantity");
                foreach (var product in listProducts){
                    Console.WriteLine($"{product.ProductId}\t{product.ProductName}\t{product.Price}\t{product.Quantity}");
                }
            }
        }
        // Tạo báo cáo sản phẩm hết hàng
        public void GenerateLowStockReport(List<Product> listProducts, int threshold){
            Console.WriteLine("---Low Stock Report---");
            Console.WriteLine("Product ID\tProduct Name\tPrice\tQuantity");
            var lowStockProducts = listProducts.Where(product => product.Quantity < threshold).ToList();
            foreach(var product in listProducts){
                Console.WriteLine($"{product.ProductId}\t{product.ProductName}\t{product.Price}\t{product.Quantity}");
            }
            if (!lowStockProducts.Any()){
                Console.WriteLine("No products are low in stock.");
            }
        }

    }
}