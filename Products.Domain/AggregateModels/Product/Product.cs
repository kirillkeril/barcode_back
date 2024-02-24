using Products.Domain.SeedWork;

namespace Products.Domain.AggregateModels.Product;

public class Product : Entity
{
    private Name _name;
    private Barcode _barcode;

    public Name Name => _name;
    public Barcode Barcode => _barcode;

    public Product(string name, string barcode)
    {
        _name = new Name(name);
        _barcode = new Barcode(barcode);
    }

    public Product(string id, string name, string barcode) : base(new Guid(id))
    {
        _name = new Name(name);
        _barcode = new Barcode(barcode);
    }
}