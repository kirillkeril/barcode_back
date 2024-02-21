using MongoDB.Driver;
using Products.BL;
using Products.Domain.AggregateModels.Product;
using Products.Infrastructure.Models;
using Microsoft.Extensions.Options;
using Products.Infrastructure.Configs;

namespace Products.Infrastructure.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly IMongoCollection<ProductModel> _mongoCollection;

    public ProductRepository(IOptions<DatabaseConnectionSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        _mongoCollection = mongoDatabase.GetCollection<ProductModel>(options.Value.ProductsCollectionName);
    }
    
    public async Task<IEnumerable<Product>> GetAll()
    {
        var models = await _mongoCollection.Find(_ => true).ToListAsync();
        var products = new List<Product>();
        models.ForEach(m =>
        {
            products.Add(new Product(m.Id, m.Name, m.Barcode));
        });
        return products;
    }

    public async Task<Product?> GetById(Guid id)
    {
        var model = await _mongoCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        var products = new Product(model.Id, model.Name, model.Barcode);
        return products;
    }

    public async Task<Product> Create(Product product)
    {
        var model = new ProductModel(product.Id, product.Name.Value, product.Barcode.Value);
        await _mongoCollection.InsertOneAsync(model);
        return product;
    }

    public async Task<Product?> Update(Guid id, string? name, string? barcode)
    {
        var oldModel = await GetById(id);
        if (oldModel == null) return null;
        var newProduct = new Product(id, name ?? oldModel.Name.Value, barcode ?? oldModel.Barcode.Value);
        var result = await _mongoCollection
            .ReplaceOneAsync(p => p.Id == id, 
                new ProductModel(newProduct.Id, newProduct.Name.Value, newProduct.Barcode.Value));
        if (result.ModifiedCount > 0) return null;
        return newProduct;
    }

    public async Task Delete(Guid id)
    {
        await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }
}