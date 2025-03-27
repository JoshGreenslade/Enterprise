using Chap3.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chap3.Repositories;

public class SqlProductRepository : IProductRepository
{

    private readonly AppDbContext _db;

    public SqlProductRepository(AppDbContext db)
    {
        _db = db;
    }
    public async Task<Product> AddAsync(Product product)
    {
        await _db.Products.AddAsync(product);
        return product;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int productId)
    {
        return await _db.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<Product?> GetByNameAsync(string name)
    {
        return await _db.Products.FirstOrDefaultAsync(p => p.Name == name);
    }

}