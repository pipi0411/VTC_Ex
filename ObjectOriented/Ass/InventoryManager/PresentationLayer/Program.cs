using System;
namespace InventoryManager{
    public class Program{
        public static void Main(){
            var productRepo = new ProductRepository("product.txt"); 
            var inventoryRepo = new InventoryRepository(productRepo); 
            var inventory = new Inventory(inventoryRepo);
            var app = new InventoryApp(inventory, inventoryRepo); // Khởi tạo InventoryApp với Inventory và InventoryRepository
            app.Run(); // Start the application
        }
    }
}