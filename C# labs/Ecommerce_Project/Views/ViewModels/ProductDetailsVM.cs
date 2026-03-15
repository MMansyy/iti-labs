using Ecommerce_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Views.ViewModels
{
    public class ProductDetailsVM
    {
        [Required]
        public Product Product { get; set; }

        public List<Product>? RelatedProducts { get; set; } = new();

    }
}
