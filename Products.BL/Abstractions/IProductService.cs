using Products.Domain.AggregateModels.Product;

namespace Products.BL.Abstractions;

public interface IProductService
{
    public Task<Product> Create(string name, string code);
    public Task<Product?> Update(Guid id, string? name, string? code);
}