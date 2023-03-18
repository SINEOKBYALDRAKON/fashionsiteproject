using System.Text.RegularExpressions;
using fashionsiteproject.Shop.Data;
using fashionsiteproject.Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Service;

public class ClothingService : IClothingProduct
{
    private readonly ApplicationDbContext _context;

     public ClothingService(ApplicationDbContext context)
     {
         _context = context;
     }

	public void DeleteClothingProducts(int id)
	{
         var clothing = GetById(id);
         if(clothing == null)
         {
             throw new ArgumentException();
         }
         _context.Remove(clothing);
         _context.SaveChanges();
	}

	public void EditClothingProducts(ClothingProduct clothing)
     {
         var model = _context.ClothingProducts.First(f => f.Id == clothing.Id);
         _context.Entry<ClothingProduct>(model).State = EntityState.Detached;
         _context.Update(clothing);
         _context.SaveChanges();
     }
	public IEnumerable<ClothingProduct> GetAll()
     {
         return _context.ClothingProducts
             .Include(clothing => clothing.Category );
     }

     public ClothingProduct GetById(int id)
     {
         return GetAll().FirstOrDefault(clothing => clothing.Id == id);
     }

     public IEnumerable<ClothingProduct> GetFilteredClothingProducts(int id, string searchQuery)
     {
         
         if(string.IsNullOrEmpty(searchQuery) || string.IsNullOrWhiteSpace(searchQuery))
         {
             return GetClothingProductsByCategoryId(id);
         }

         return GetFilteredClothingProducts(searchQuery).Where(clothing => clothing.Category.Id == id);
     }

     public IEnumerable<ClothingProduct> GetFilteredClothingProducts(string searchQuery)
     {
         var queries = string.IsNullOrEmpty(searchQuery) ? null : Regex.Replace(searchQuery, @"\s+", " ").Trim().ToLower().Split(" ");
         if(queries == null)
         {
             return null;
         }

         return GetAll().Where(item => queries.Any(query => (item.Name.ToLower().Contains(query))));
     }

     public IEnumerable<ClothingProduct> GetClothingProductsByCategoryId(int categoryId)
     {
         return GetAll().Where(clothing => clothing.Category.Id == categoryId);
     }
     
     public void NewClothingProducts(ClothingProduct clothing)
     {
         _context.Add(clothing);
         _context.SaveChanges();
     }
}