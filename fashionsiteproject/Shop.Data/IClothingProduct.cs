using fashionsiteproject.Shop.Data.Models;

namespace fashionsiteproject.Shop.Data
{
    public interface IClothingProduct
    {
        IEnumerable<ClothingProduct> GetAll();
        IEnumerable<ClothingProduct> GetPreferred(int count);
        IEnumerable<ClothingProduct> GetFoodProductsByCategoryId(int categoryId);
        IEnumerable<ClothingProduct> GetFilteredFoodProducts(int id, string searchQuery);
        IEnumerable<ClothingProduct> GetFilteredFoodProducts(string searchQuery);

        IClothingProduct GetById(int id);

        void NewClothingProducts(ClothingProduct clothingProducts);
        void EditClothingProducts(ClothingProduct clothingProducts);
        void DeleteClothingProducts(int id);
    }
}
