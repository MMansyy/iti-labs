using Microsoft.AspNetCore.Identity;

namespace Lab_3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
