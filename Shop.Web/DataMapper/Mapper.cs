using fashionsiteproject.Models.Category;
using fashionsiteproject.Models.Clothing;
using fashionsiteproject.Models.Home;
using fashionsiteproject.Shop.Data;
using fashionsiteproject.Shop.Data.Models;
using Shop.Web.Views.Clothing;

namespace Shop.Web.DataMapper;

public class Mapper
{
    public Category CategoryListingToModel(CategoryListingModel model)
    {
        return new Category
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Image = model.ImageUrl,
        };
    }

    public CategoryListingModel ClothingToCategoryListing(ClothingProduct clothing)
    {
        return CategoryToCategoryListing(clothing.Category);
    }

    public CategoryListingModel CategoryToCategoryListing(Category category)
    {
        return new CategoryListingModel
        {
            Name = category.Name,
            Description = category.Description,
            Id = category.Id,
            ImageUrl = category.Image,
        };
    }

    public NewClothingModel ClothingToNewClothingModel(ClothingProduct clothing)
    {
        return new NewClothingModel
        {
            Id = clothing.Id,
            Name = clothing.Name,
            CategoryId = clothing.CategoryId,
            ImageUrl = clothing.Image,
            InStock = clothing.InStock,
            LongDescription = clothing.LongDescription,
            Price = (decimal)clothing.Price,
            ShortDescription = clothing.ShortDescription,
        };
    }

    public ClothingProduct NewClothingModelToClothing(NewClothingModel model, bool newInstance, ICategory category)
    {
        var clothing = new ClothingProduct
        {
            Name = model.Name,
            Category = category.GetById(model.CategoryId.Value),
            CategoryId = model.CategoryId.Value,
            Image = model.ImageUrl,
            InStock = model.InStock.Value,
            LongDescription = model.LongDescription,
            Price = model.Price.Value,
            ShortDescription = model.ShortDescription,
        };

        if (!newInstance)
        {
            clothing.Id = model.Id;
        }

        return clothing;
    }

    private IEnumerable<ClothingSummaryModel> ClothingToClothingSummaryModel(IEnumerable<ClothingProduct> clothing)
    {
        return clothing.Select(clothing => new ClothingSummaryModel
        {
            Name = clothing.Name,
            Id = clothing.Id,
        });
    }

    public HomeIndexModel ClothingToHomeIndexModel(IEnumerable<ClothingProduct> clothing)
    {
        var clothingListing = clothing.Select(clothing => new ClothingListingModel
        {
            Id = clothing.Id,
            Name = clothing.Name,
            Category = CategoryToCategoryListing(clothing.Category),
            ImageUrl = clothing.Image,
            InStock = clothing.InStock,
            Price = clothing.Price,
            ShortDescription = clothing.ShortDescription,
        });

        return new HomeIndexModel
        {
            ClothingList = clothingListing
        };
    }
}