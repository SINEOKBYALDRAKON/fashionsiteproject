using fashionsiteproject.Shop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fashionsiteproject.Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasIndex(user => user.Email).IsUnique(true);
        }

        public DbSet<ClothingProduct> ClothingProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }
    }
}
