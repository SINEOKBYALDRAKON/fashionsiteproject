using fashionsiteproject.Models.Category;
using fashionsiteproject.Models.Clothing;
using fashionsiteproject.Shop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Web.DataMapper;

namespace fashionsiteproject.Controllers;

public class ClothingController : Controller
{ 
    private readonly ICategory _categoryService;
    private readonly IClothingProduct _clothingService;
    private readonly Mapper _mapper;

    public ClothingController(ICategory categoryService, IClothingProduct clothingService)
    {
        _categoryService = categoryService;
        _clothingService = clothingService;
        _mapper = new Mapper();
    }

    [Route("Clothes/{id}")]
    public IActionResult Index(int id)
    {
        var clothing = _clothingService.GetById(id);

        var model = new ClothingIndexModel
        {
            Id = clothing.Id,
            Name = clothing.Name,
            ImageUrl = clothing.Image,
            InStock = clothing.InStock,
            Price = clothing.Price,
            Description = clothing.ShortDescription + "\n" + clothing.LongDescription,
            CategoryId = clothing.Category.Id,
            CategoryName = clothing.Category.Name
        };

        return View(model);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult New(int categoryId = 0)
    {
        GetCategoriesForDropDownList();
        NewClothingModel model = new NewClothingModel
        {
            CategoryId = categoryId
        };

        ViewBag.ActionText = "create";
        ViewBag.Action = "New";
        ViewBag.CancelAction = "Topic";
        ViewBag.SubmitText = "Create Clothing";
        ViewBag.RouteId = categoryId;
        ViewBag.ControllerName = "Category";

        if (categoryId == 0)
        {
            ViewBag.CancelAction = "Index";
            ViewBag.ControllerName = "Home";
        }

        return View("CreateEdit", model);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult New(NewClothingModel model)
    {
        if (ModelState.IsValid && _categoryService.GetById(model.CategoryId.Value) != null)
        {
            var clothing = _mapper.NewClothingModelToClothing(model, true, _categoryService);
            _clothingService.NewClothingProducts(clothing);
            return RedirectToAction("Index", new { id = clothing.Id });
        }
        GetCategoriesForDropDownList();

        ViewBag.ActionText = "Create";
        ViewBag.Action = "New";
        ViewBag.ControllerName = "Category";
        ViewBag.CancelAction = "Topic";
        ViewBag.SubmitText = "Create Clothing";
        ViewBag.RouteId = model.CategoryId;

        return View("CreateEdit", model);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        ViewBag.ActionText = "Change";
        ViewBag.Action = "Edit";
        ViewBag.CancelAction = "Index";
        ViewBag.SubmitText = "Save Changes";
        ViewBag.ControllerName = "Clothing";
        ViewBag.RouteId = id;
        
        GetCategoriesForDropDownList();

        var clothing = _clothingService.GetById(id);
        if (clothing != null)
        {
            var model = _mapper.ClothingToNewClothingModel(clothing);
            return View("CreateEdit", model);
        }

        return View("CreateEdit");
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(NewClothingModel model)
    {
        if (ModelState.IsValid)
        {
            var clothing = _mapper.NewClothingModelToClothing(model, false, _categoryService);
            _clothingService.EditClothingProducts(clothing);
            return RedirectToAction("Index", new { id = model.Id });
        }

        ViewBag.ActionText = "change";
        ViewBag.Action = "Edit";
        ViewBag.CancelAction = "Index";
        ViewBag.SubmitText = "Save Changes";
        ViewBag.ControllerName = "Clothing";
        ViewBag.RouteId = model.Id;
        GetCategoriesForDropDownList();

        return View("CreateEdit", model);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var categoryId = _clothingService.GetById(id).CategoryId;
        _clothingService.DeleteClothingProducts(id);

        return RedirectToAction("Topic", "Category", new { id = categoryId, searchQuery = "" });
    }

    private void GetCategoriesForDropDownList()
    {
        var categories = _categoryService.GetAll().Select(category => new CategoryDropdownModel
        {
            Id = category.Id,
            Name = category.Name,
        });
        //ViewBag.Categoris = new SelectList(categories, "Id", "Name");
    }
}