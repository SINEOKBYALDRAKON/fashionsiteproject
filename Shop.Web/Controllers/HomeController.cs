using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using fashionsiteproject.Models;
using fashionsiteproject.Shop.Data;
using Shop.Web.DataMapper;

namespace fashionsiteproject.Controllers;

public class HomeController : Controller
{
    private readonly IClothingProduct _clothingService;
    private readonly Mapper _mapper;
    
    public HomeController(IClothingProduct clothingService)
    {
        _clothingService = clothingService;
        _mapper = new Mapper();
    }

    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }

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