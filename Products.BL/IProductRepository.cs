using Products.Domain.AggregateModels.Product;

namespace Products.BL;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAll();
    public Task<Product?> GetById(Guid id);
    public Task<Product> Create(Product product);
    public Task<Product?> Update(Guid id, string? name, string? barcode);
    public Task Delete(Guid id);
}