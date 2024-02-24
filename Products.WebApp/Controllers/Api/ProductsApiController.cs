using Microsoft.AspNetCore.Mvc;
using Products.BL;
using Products.BL.Abstractions;
using Products.Domain.SeedWork;
using Products.WebApp.Models;

namespace Products.WebApp.Controllers.Api;

public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository productRepository, IProductService productService, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        return Results.Json(await _productRepository.GetAll());
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] ProductViewModel product)
    {
        try
        {
            var result = await this._productService.Create(product.Name, product.Barcode);
            var model = new ProductViewModel(result.Id.ToString(), result.Name.Value, result.Barcode.Value);
            return Results.Json(model, statusCode: StatusCodes.Status201Created);
        }
        catch (DomainException e)
        {
            _logger.LogDebug("{0}", e.Message);
            return Results.BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError("Message: {1}: {0}", e.StackTrace, e.Message);
            return Results.Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPost]
    public async Task<IResult> Update(Guid id, [FromBody] ProductViewModel product)
    {
        try
        {
            var result = await this._productService.Create(product.Name, product.Barcode);
            var model = new ProductViewModel(result.Id.ToString(), result.Name.Value, result.Barcode.Value);
            return Results.Json(model, statusCode: StatusCodes.Status201Created);
        }
        catch (DomainException e)
        {
            _logger.LogDebug("{0}", e.Message);
            return Results.BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError("Message: {1}: {0}", e.StackTrace, e.Message);
            return Results.Problem(statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}