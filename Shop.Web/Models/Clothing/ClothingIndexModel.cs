using System.Globalization;

namespace fashionsiteproject.Models.Clothing;

public class ClothingIndexModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int InStock { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public string Total
    {
        get => (Price * Amount).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
    }
    public string CategoryName { get; set; }
}