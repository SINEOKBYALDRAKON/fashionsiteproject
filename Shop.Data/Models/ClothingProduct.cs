namespace fashionsiteproject.Shop.Data.Models
{
    public class ClothingProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Price { get; set; }
        public string Image { get; set; }

        public int InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public ClothingProduct() {}
        
        public ClothingProduct(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
