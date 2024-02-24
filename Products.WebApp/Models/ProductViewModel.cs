namespace Products.WebApp.Models;

public class ProductViewModel
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }

    public ProductViewModel()
    {
        Name = "";
        Barcode = "";
    }

    public ProductViewModel(string name, string code)
    {
        Name = name;
        Barcode = code;
    }

    public ProductViewModel(string id, string name, string code)
    {
        Id = id;
        Name = name;
        Barcode = code;
    }
}