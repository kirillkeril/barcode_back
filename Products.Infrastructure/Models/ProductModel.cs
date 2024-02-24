using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Products.Infrastructure.Models;

public class ProductModel
{
    [BsonId]
    public string Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("barcode")]
    public string Barcode { get; set; }

    public ProductModel(string name, string barcode)
    {
        Name = name;
        Barcode = barcode;
    }
    public ProductModel(string id, string name, string barcode)
    {
        Id = id;
        Name = name;
        Barcode = barcode;
    }
}