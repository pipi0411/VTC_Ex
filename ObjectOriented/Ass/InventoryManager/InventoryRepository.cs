using System;
using System.Collections.Generic;
using System.Linq;
namespace InventoryManager{
    // Lớp InventoryRepository
    public class InventoryRepository{
        // Đường dẫn file lưu trữ thông tin kho hàng
       private readonly ProductRepository _productRepository;
       // Khởi tạo InventoryRepository với ProductRepository để quản lý sản phẩm
         public InventoryRepository(ProductRepository productRepository){
             _productRepository = productRepository;
         }
        // Cập nhật số lượng sản phẩm
        public void UpdateStock(int productId, int quantity){
            var products = _productRepository.GetAllProducts();
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null){
                Console.WriteLine("Product not found");
                return;
            }
            // Giảm số lượng sản phẩm
            product.Quantity -= quantity;
            if (product.Quantity < 0){
                Console.WriteLine("Out of stock");
                product.Quantity = 0; // Đặt lại số lượng sản phẩm về 0
            }
            _productRepository.UpdateProduct(product);
            Console.WriteLine("Stock updated successfully");
        }
        // Phương thức lấy danh sách sản phẩm có số lượng tồn kho thấp hơn ngưỡng threshold
        public List<Product> GetLowStockProducts(int threshold){
            var products = _productRepository.GetAllProducts();
            return products.Where(p => p.Quantity < threshold).ToList();
        }
    }
}