using Products.Domain.AggregateModels.Product;

namespace Products.BL;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAll();
    public Task<Product?> GetById(string id);
    public Task<Product> Create(Product product);
    public Task<Product?> Update(string id, string? name, string? barcode);
    public Task Delete(string id);
}