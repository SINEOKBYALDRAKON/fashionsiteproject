using fashionsiteproject.Shop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.DataMapper;

namespace fashionsiteproject.Controllers;

public class ClothingController
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
        var clothes = _clothingService.GetById(id);
        
    }

    [Authorize(Roles = "Admin")]
    public IActionResult New(int categoryId = 0)
    {
        
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult New(NewClothingModel model)
    {
        
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(NewFoodModel model)
    {
        
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        
    }
}