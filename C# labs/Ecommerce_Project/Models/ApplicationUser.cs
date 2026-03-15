using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class ApplicationUser : IdentityUser
    {

        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; }


        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
