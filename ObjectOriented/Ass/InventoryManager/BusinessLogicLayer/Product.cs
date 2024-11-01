using System;
using System.Globalization;

namespace InventoryManager{
    // Lớp Product
    public class Product{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set;}
        // Constructor
        public Product(int productId, string productName, double price, int quantity){
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
        // Hiển thị thông tin sản phẩm
        public void Display(){
            string format = Price.ToString("C", new CultureInfo("vi-VN"));
            Console.WriteLine($"Product ID: {ProductId}, Product Name: {ProductName}, Price: {format}, Quantity: {Quantity}");
        }
    }
}