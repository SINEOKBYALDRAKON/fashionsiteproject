namespace fashionsiteproject.Shop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public IEnumerable<OrderDetails> orderDetails { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
