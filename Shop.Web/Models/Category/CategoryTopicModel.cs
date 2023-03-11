using fashionsiteproject.Models.Clothing;

namespace fashionsiteproject.Models.Category;

public class CategoryTopicModel
{
    public CategoryListingModel Category { get; set; }
    public IEnumerable<ClothingListingModel> Clothing { get; set; }
    public string SearchQuery { get; set; }
}