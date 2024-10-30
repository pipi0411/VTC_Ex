using System;
namespace InventoryManager{
    public class Program{
        public static void Main(){
            var productRepo = new ProductRepository("product.txt"); 
            var inventoryRepo = new InventoryRepository(productRepo); 
            var inventory = new Inventory(inventoryRepo);
            var app = new InventoryApp(inventory);
            app.Run(); // Start the application
        }
    }
}