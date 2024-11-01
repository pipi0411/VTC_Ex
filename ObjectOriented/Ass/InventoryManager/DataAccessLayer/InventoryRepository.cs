using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager
{
    // Lớp InventoryRepository
    public class InventoryRepository
    {
        private readonly ProductRepository _productRepository; // Lưu trữ đối tượng ProductRepository

        // Khởi tạo InventoryRepository với ProductRepository
        public InventoryRepository(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Thêm sản phẩm vào kho
        public void Add(Product product)
        {
            _productRepository.AddProduct(product); // Sử dụng phương thức AddProduct từ ProductRepository
        }

        // Cập nhật sản phẩm trong kho
        public void Update(Product product)
        {
            _productRepository.UpdateProduct(product); // Sử dụng phương thức UpdateProduct từ ProductRepository
        }

        // Xóa sản phẩm khỏi kho
        public void Delete(int productId)
        {
            _productRepository.RemoveProduct(productId); // Sử dụng phương thức RemoveProduct từ ProductRepository
        }

        // Lấy tất cả sản phẩm từ kho
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts(); // Sử dụng phương thức GetAllProducts từ ProductRepository
        }

        // Tìm sản phẩm theo mã sản phẩm
        public Product FindProduct(int productId)
        {
            return _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
        }

        // Lấy danh sách sản phẩm có số lượng tồn kho thấp hơn ngưỡng threshold
        public List<Product> GetLowStockProducts(int threshold)
        {
            return _productRepository.GetAllProducts().Where(p => p.Quantity < threshold).ToList();
        }
    }
}
