using fashionsiteproject.Shop.Data.Models;

namespace fashionsiteproject.Shop.Data
{
    public interface IClothingProduct
    {
        IEnumerable<ClothingProduct> GetAll();
        IEnumerable<ClothingProduct> GetClothingProductsByCategoryId(int categoryId);
        IEnumerable<ClothingProduct> GetFilteredClothingProducts(int id, string searchQuery);
        IEnumerable<ClothingProduct> GetFilteredClothingProducts(string searchQuery);

        ClothingProduct GetById(int id);

        void NewClothingProducts(ClothingProduct clothingProducts);
        void EditClothingProducts(ClothingProduct clothingProducts);
        void DeleteClothingProducts(int id);
    }
}
