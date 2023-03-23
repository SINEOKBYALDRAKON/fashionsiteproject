using fashionsiteproject.Models.Category;
using fashionsiteproject.Models.Clothing;
using fashionsiteproject.Shop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.DataMapper;

namespace fashionsiteproject.Controllers;

public class CategoryController : Controller
{
    private readonly ICategory _categoryService;
		private readonly IClothingProduct _clothingService;
        private readonly Mapper _mapper;

		public CategoryController(ICategory categoryService, IClothingProduct clothingService)
		{
			_categoryService = categoryService;
			_clothingService = clothingService;
            _mapper = new Mapper();
		}

		public IActionResult Index()
		{
			var categories = _categoryService.GetAll().
				Select(category => new CategoryListingModel
				{
					Name = category.Name,
					Description = category.Description,
					Id = category.Id,
					ImageUrl = category.Image
				});

			var model = new CategoryIndexModel
			{
				CategoryList = categories
			};

			return View(model);
		}

		public IActionResult Topic(int id, string searchQuery)
		{
			var category = _categoryService.GetById(id);
			var clothing = _clothingService.GetFilteredClothingProducts(id, searchQuery);

			var clothingListings = clothing.Select(clothing => new ClothingListingModel
			{
				Id = clothing.Id,
				Name = clothing.Name,
				InStock = clothing.InStock,
				Price = clothing.Price,
				ShortDescription = clothing.ShortDescription,
				Category = _mapper.ClothingToCategoryListing(clothing),
				ImageUrl = clothing.Image
			});

			var model = new CategoryTopicModel
			{
				Category = _mapper.CategoryToCategoryListing(category),
				Clothing = clothingListings
			};

			return View(model);
		}

		public IActionResult Search(int id, string searchQuery)
		{
			return RedirectToAction("Topic", new { id, searchQuery });
		}

		[Authorize(Roles = "Admin")]
		public IActionResult New()
		{
			ViewBag.ActionText = "create";
			ViewBag.Action = "New";
			ViewBag.CancelAction = "Index";
			ViewBag.SubmitText = "Create Category";
			return View("CreateEdit");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult New(CategoryListingModel model)
		{
			if (ModelState.IsValid)
			{
				var category = _mapper.CategoryListingToModel(model);
				_categoryService.NewCategory(category);
				return RedirectToAction("Topic", new { id = category.Id, searchQuery = "" });
			}

			ViewBag.ActionText = "create";
			ViewBag.Action = "New";
			ViewBag.CancelAction = "Index";
			ViewBag.SubmitText = "Create Category";

			return View("CreateEdit", model);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Edit(int id)
		{
            ViewBag.ActionText = "change";
            ViewBag.Action = "Edit";
            ViewBag.CancelAction = "Topic";
            ViewBag.SubmitText = "Save Changes";
            ViewBag.RouteId=id;

			var category = _categoryService.GetById(id);
			if (category != null)
			{
				var model = _mapper.CategoryToCategoryListing(category);
				return View("CreateEdit" ,model);
			}

			return View("CreateEdit");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult Edit(CategoryListingModel model)
		{
			if (ModelState.IsValid)
			{
				var category = _mapper.CategoryListingToModel(model);
				_categoryService.EditCategory(category);
				return RedirectToAction("Topic", new { id = category.Id, searchQuery = "" });
			}

            ViewBag.ActionText = "change";
            ViewBag.Action = "Edit";
            ViewBag.CancelAction = "Topic";
            ViewBag.SubmitText = "Save Changes";
            ViewBag.RouteId=model.Id;

			return View("CreateEdit",model);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Delete(int id)
		{
			_categoryService.DeleteCategory(id);

			return RedirectToAction("Index");
		}
}