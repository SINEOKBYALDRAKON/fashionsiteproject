using fashionsiteproject.Shop.Data.Models;

namespace fashionsiteproject.Shop.Data
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);

        void NewCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
