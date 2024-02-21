using Products.Domain.AggregateModels.Product;

namespace Products.BL.Abstractions;

public interface IProductService
{
    public Product Create(string name, string code);
    public Product Update(Guid id, string? name, string? code);
}