using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;

namespace Ecommerce_Project.Views.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;

        public string? ImageUrl { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
