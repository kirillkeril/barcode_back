using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products.BL;
using Products.WebApp.Models;

namespace Products.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ResponseCache(Duration = 1, Location = ResponseCacheLocation.Client, NoStore = false)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}