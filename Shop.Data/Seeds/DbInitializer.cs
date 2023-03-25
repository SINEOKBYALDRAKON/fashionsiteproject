using fashionsiteproject.Shop.Data;
using fashionsiteproject.Shop.Data.Models;

namespace Shop.Data.Seeds
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                if (!context.ClothingProducts.Any())
                {
                    var clothingProducts = new ClothingProduct[]
                    {
                        new ClothingProduct
                        {
                            Name = "T-Shirt",
                            Category = categories["Men"],
                            Image = "41",
                            InStock = 20,
                            ShortDescription = "MAMA TOLD ME NOT TO SELL WORK(MAMA)",
                            LongDescription = "mdiwao",
                            Price = 20000000,
                        },
                    };
                    context.ClothingProducts.AddRange(clothingProducts);
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category
                        {
                            Name = "What's New",
                            Description = "What is new",
                            Image = "https://images.pexels.com/photos/533360/pexels-photo-533360.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450",
                        },
                        new Category
                        {
                            Name = "Men",
                            Description = "Men's Clothes",
                            Image = "https://images.pexels.com/photos/8066/fruits-market-colors.jpg?auto=compress&cs=tinysrgb&dpr=1&w=450"
                        },
                        new Category
                        {
                            Name = "Women",
                            Description = "Women's Clothes",
                            Image = "https://images.pexels.com/photos/1537169/pexels-photo-1537169.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450"
                        },
                        new Category
                        {
                            Name = "Children",
                            Description = "Children's Clothes",
                            Image = "https://images.pexels.com/photos/65175/pexels-photo-65175.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450"
                        },
                        new Category
                        {
                            Name = "Jewelry",
                            Description = "Jewelry",
                            Image = "https://images.pexels.com/photos/416656/pexels-photo-416656.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=450&w=450"
                        }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        //genre.ImageUrl = $"/images/Categories/{genre.Name}.png";
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }
    }
}