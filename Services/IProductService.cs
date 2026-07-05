using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementApi.Models;

namespace ProductManagementApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> SearchProductsByCategoryAsync(string category);
    }
}
