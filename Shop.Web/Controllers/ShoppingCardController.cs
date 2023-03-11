using fashionsiteproject.Models.ShoppingCard;
using fashionsiteproject.Shop.Data;
using fashionsiteproject.Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace fashionsiteproject.Controllers;

public class ShoppingCardController : Controller
{
    private readonly IClothingProduct _clothingService;
    private readonly ShoppingCard _shoppingCard;

    public ShoppingCardController(IClothingProduct clothingService, ShoppingCard shoppingCard)
    {
        _clothingService = clothingService;
        _shoppingCard = shoppingCard;
    }

    public IActionResult Index(bool isValidAmount = true, string returnUrl = "/")
    {
        _shoppingCard.GetShoppingCardItems();

        var model = new ShoppingCardIndexModel
        {
            ShoppingCard = _shoppingCard,
            ShoppingCardTotal = _shoppingCard.GetShoppingCardTotal(),
            ReturnUrl = returnUrl
        };

        if (!isValidAmount)
        {
            ViewBag.InvalidAmountText = "*There were not enough items in stock to add*";
        }

        return View("Index", model);
    }

    [HttpGet]
    [Route("/ShoppingCart/Add/{id}/{returnUrl?}")]
    public IActionResult Add(int id, int? amount = 1, string returnUrl=null )
    {
        var food = _clothingService.GetById(id);
        returnUrl = returnUrl.Replace("%2F", "/");
        bool isValidAmount = false;
        if (food != null)
        {
            isValidAmount = _shoppingCard.AddToCard(food, amount.Value);
        }

        return Index(isValidAmount, returnUrl);
    }

    public IActionResult Remove(int foodId)
    {
        var food = _clothingService.GetById(foodId);
        if (food != null)
        {
            _shoppingCard.RemoveFromCard(food);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Back(string returnUrl="/")
    {
        return Redirect(returnUrl);
    }
}