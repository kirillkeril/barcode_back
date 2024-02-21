using Products.Domain.SeedWork;

namespace Products.Domain.AggregateModels.Product;

public class Product : Entity
{
    private Name _name;
    private Barcode _barcode;

    public Name Name => _name;
    public Barcode Barcode => _barcode;

    public void SetName(string name)
    {
        _name = new Name(name);
    }

    public void SetBarcode(string barcode)
    {
        _barcode = new global::Products.Domain.AggregateModels.Product.Barcode(barcode);
    }

    public Product(string name, string barcode)
    {
        _name = new Name(name);
        _barcode = new global::Products.Domain.AggregateModels.Product.Barcode(barcode);
    }

    public Product(Guid id, string name, string barcode) : base(id)
    {
        _name = new Name(name);
        _barcode = new Barcode(barcode);
    }
}