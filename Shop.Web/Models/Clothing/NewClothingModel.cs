using System.ComponentModel.DataAnnotations;

namespace fashionsiteproject.Models.Clothing;

public class NewClothingModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the clothing")]
    [Display(Name = "Clothing name")]
    [StringLength(20)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please enter the url of the clothing image")]
    [Display(Name = "Image Url")]
    public string ImageUrl { get; set; }
    [Display(Name = "Short Description")]
    public string ShortDescription { get; set; }
    [Display(Name = "Long Description")]
    public string LongDescription { get; set; }
    
    [Required(ErrorMessage ="Please enter price of the food")]
    [Range(0.1,double.MaxValue)]
    [Display(Name = "Price*")]
    public decimal? Price { get; set; }
    
    [Range(0,Double.MaxValue)]
    [Required(ErrorMessage = "Please enter how many is left in stock")]
    [Display(Name = "In stock*")]
    public int? InStock { get; set; }
    [Required(ErrorMessage = "Please select category")]
    [Range(1,double.MaxValue)]
    public int? CategoryId { get; set; }
}