using fashionsiteproject.Models.Clothing;

namespace fashionsiteproject.Models.Home;

public class HomeIndexModel
{
    public string SearchQuery { get; set; }
    public IEnumerable<ClothingListingModel> ClothingList { get; set; }
}