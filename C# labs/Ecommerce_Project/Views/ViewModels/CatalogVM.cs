using Ecommerce_Project.Models;

namespace Ecommerce_Project.Views.ViewModels
{
    public class CatalogVM
    {
        public int? CategoryId { get; set; }

        public string QuerySearch { get; set; } = string.Empty;

        public string SortBy { get; set; } = "name_asc";

        public int PageNumber { get; set; } = 1;

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public List<Product> Products { get; set; } = new();

        public List<Category> Categories { get; set; } = new();

    }
}
