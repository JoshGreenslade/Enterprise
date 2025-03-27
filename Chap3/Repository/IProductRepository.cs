using Chap3.Domain;

namespace Chap3.Repositories;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);

    Task<List<Product>> GetAllProductsAsync();
    Task<Product?> GetByIdAsync(int productId);
    Task<Product?> GetByNameAsync(string name);
}