namespace fashionsiteproject.Shop.Data.Models
{
    public class ShoppingCardItem
    {
        public int Id { get; set; }
        public ClothingProduct ClothingProduct { get; set; }
        public int Amount { get; set; }
        public int ShoppingCardId { get; set; }
    }
}
