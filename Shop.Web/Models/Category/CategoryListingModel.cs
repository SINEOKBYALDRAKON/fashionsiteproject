using System.ComponentModel.DataAnnotations;

namespace fashionsiteproject.Models.Category;

public class CategoryListingModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the category")]
    [Display(Name = "Category Name")]
    [StringLength(20)]
    public string Name { get; set; }
    
    [Display(Name = "Description")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please enter url of the category image")]
    [Display(Name = "Image url")]
    public string ImageUrl { get; set; }
}