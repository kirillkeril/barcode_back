using Products.BL.Abstractions;
using Products.Domain.AggregateModels.Product;

namespace Products.BL.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Create(string name, string code)
    {
        Console.WriteLine("хуй");
        Console.WriteLine(name);
        Console.WriteLine(code);
        var product = new Product(name, code);
        var result = await _productRepository.Create(product);
        return result;
    }

    public async Task<Product?> Update(Guid id, string? name, string? code)
    {
        var result = await _productRepository.Update(id.ToString(), name, code);
        return result;
    }
}