using Chap3.Domain;
using Chap3.Repositories;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> AddNewProduct(string name)
    {
        var product = new Product
        {
            Name = name
        };
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return product;
    }
    public async Task<Product> GetByName(string name)
    {

        var product = await _productRepository.GetByNameAsync(name);
        if (product == null) throw new ArgumentException("");
        return product;
    }
}