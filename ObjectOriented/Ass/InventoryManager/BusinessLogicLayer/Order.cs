using System;
using System.Collections.Generic;
using System.IO;

namespace InventoryManager{
    // Lớp Order
    public class Order{
        public int OrderId { get; set; }
        public Product? Product { get; private set; }
        public int Quantity { get; private set; }
        public DateTime OrderDate { get; private set; }

        private readonly InventoryRepository _inventoryRepository; // Thêm biến lưu InventoryRepository
        // Constructor nhận InventoryRepository để cập nhật file
        public Order(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            OrderId = new Random().Next(1, 1000); // Tạo OrderId ngẫu nhiên
        }
        // Tạo đơn hàng mới 
        public bool CreadOrder(Product product, int quantity){
            if (!ValidateStock(product, quantity)){
                Console.WriteLine("Not enough stock to create order");
                return false;
            }
            Product = product;
            Quantity = quantity;
            product.Quantity -= quantity; // Giảm số lượng tồn kho
            // Gọi phương thức cập nhật để ghi thay đổi vào file
            _inventoryRepository.Update(product);
            LogOrder(product, quantity); // Ghi log đơn hàng
            Console.WriteLine("Create order successfully");
            return true;
        }
        // Kiểm tra số lượng tồn kho
        private bool ValidateStock(Product product, int quantity){
            return product.Quantity >= quantity;
        }
        // Ghi log đơn hàng
        private void LogOrder(Product product, int quantity){
            string orderInfo = $"Order ID: {OrderId}, Product ID: {Product.ProductId}, Product Name: {Product.ProductName}, Quantity: {Quantity}, Order Date: {OrderDate}";
            string filePath = "order.txt";

            try{
                File.AppendAllText(filePath, orderInfo + Environment.NewLine);
                Console.WriteLine("Log order successfully");
            }
            catch (Exception e){
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        // Hiển thị thông tin đơn hàng
        public static void DisplayOrder(){
            string filePath = "order.txt";
            if(!File.Exists(filePath)){
                Console.WriteLine("No order available.");
                return;
            }
            try{
                string[] orders = File.ReadAllLines(filePath);
                if(orders.Length == 0){
                    Console.WriteLine("No order available.");
                    return;
                }
                Console.WriteLine("---Order List---");
                foreach (var order in orders){
                    Console.WriteLine(order);
                }
            }
            catch (Exception e){
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}