using Microsoft.AspNetCore.Identity;

namespace fashionsiteproject.Shop.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public decimal Balance { get; set; }

        public string FirstAddressLine { get; set; }
        public string SecondAddressLine { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
    }
}
