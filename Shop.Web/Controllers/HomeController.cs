using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fashionsiteproject.Models;
using fashionsiteproject.Shop.Data;
using Shop.Web.DataMapper;

namespace fashionsiteproject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IClothingProduct _clothingService;
    private readonly Mapper _mapper;
    
    public HomeController(ILogger<HomeController> logger, IClothingProduct clothingService)
    {
        _logger = logger;
        _clothingService = clothingService;
        _mapper = new Mapper();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Search(string searchQuery)
    {
        if (string.IsNullOrWhiteSpace(searchQuery) || string.IsNullOrEmpty(searchQuery))
        {
            return RedirectToAction("Index");
        }

        var searchedClothing = _clothingService.GetFilteredClothingProducts(searchQuery);
        var model = _mapper.ClothingToHomeIndexModel(searchedClothing);

        return View(model);
    }
}