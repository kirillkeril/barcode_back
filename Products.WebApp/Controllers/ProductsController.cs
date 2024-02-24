using Microsoft.AspNetCore.Mvc;
using Products.BL;
using Products.BL.Abstractions;
using Products.Domain.SeedWork;
using Products.WebApp.Models;

namespace Products.WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, IProductRepository productRepository,
        ILogger<ProductsController> logger)
    {
        this._productService = productService;
        _productRepository = productRepository;
        _logger = logger;
    }

    [Route("[controller]")]
    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAll();
        return View(products);
    }

    [HttpGet]
    [Route("[controller]/{id:guid}")]
    public async Task<IActionResult> Update(Guid id)
    {
        var result = await _productRepository.GetById(id.ToString());
        if (result == null) return View();

        var model = new ProductViewModel(result.Id.ToString(), result.Name.Value, result.Barcode.Value);
        return View(model);
    }

    [ValidateAntiForgeryToken]
    [HttpPatch]
    [Route("[controller]/{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ProductViewModel product)
    {
        try
        {
            var result = await _productService.Update(id, product.Name, product.Barcode);
            if (result == null) return View();
            var model = new ProductViewModel(result.Id.ToString(), result.Name.Value, result.Barcode.Value);
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError("{0} {1}", e.Message, product.Id);
            throw;
        }
    }

    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult Create()
    {
        var model = new CreateProductViewModel();
        return View(model);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [Route("[controller]/[action]")]
    public async Task<IActionResult> Create(CreateProductViewModel product)
    {
        if (!ModelState.IsValid)
        {
            var model = new CreateProductViewModel
            {
                Messages = { ModelState.IsValid.ToString() }
            };
            return View(model);
        }

        try
        {
            var result = await _productService.Create(product.Model.Name, product.Model.Barcode);
            var model = new CreateProductViewModel
            {
                Model = new ProductViewModel(result.Id.ToString(), result.Name.Value, result.Barcode.Value),
                Messages = { $"\"{product.Model.Name}\" успешно создано!" }
            };
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError("{0}, {1}, {2}", e.Message, product.Model.Name, product.Model.Barcode);
            var model = new CreateProductViewModel
            {
                Model = new ProductViewModel(product.Model.Name, product.Model.Barcode),
                Messages = new List<string> { e.Message },
            };
            return View(model);
        }
    }
}