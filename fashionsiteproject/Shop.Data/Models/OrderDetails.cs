namespace fashionsiteproject.Shop.Data.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodProductsId { get; set; }

        //TODO da sloja broqch za productite primerno iskam 2 banana
        public int Amount { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public ClothingProduct ClothingProduct { get; set; }
    }
}
