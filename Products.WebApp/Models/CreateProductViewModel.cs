namespace Products.WebApp.Models;

public class CreateProductViewModel
{
    public ProductViewModel Model { get; set; } = new();
    public List<string> Messages { get; set; } = new();
}