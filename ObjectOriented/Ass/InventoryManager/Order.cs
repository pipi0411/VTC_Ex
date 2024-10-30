using System;
using System.Collections.Generic;
using System.Linq;
namespace InventoryManager{
    // Lớp Order
    public class Order{
        public int OrderId { get; set; }
        public Product? Product { get; private set; }
        public int Quantity { get; private set; }
        // Tạo đơn hàng mới 
        public bool CreadOrder(Product product, int quantity){
            if (!ValidateStock(product, quantity)){
                Console.WriteLine("Not enough stock to create order");
                return false;
            }
            Product = product;
            Quantity = quantity;
            product.Quantity -= quantity; // Giảm số lượng tồn kho
            Console.WriteLine("Create order successfully");
            return true;
        }
        // Kiểm tra số lượng tồn kho
        private bool ValidateStock(Product product, int quantity){
            return product.Quantity >= quantity;
        }
    }
}