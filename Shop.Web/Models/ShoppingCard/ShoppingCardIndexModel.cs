namespace fashionsiteproject.Models.ShoppingCard;

public class ShoppingCardIndexModel
{
    public Shop.Data.Models.ShoppingCard ShoppingCard { get; set; }
    public decimal ShoppingCardTotal { get; set; }
    public string ReturnUrl { get; set; }
}