using Ecommerce_Project.Models;

namespace Ecommerce_Project.Views.ViewModels
{
    public class HomeVM
    {
        public int ProductsCount { get; set; }
        public int CategoriesCount { get; set; }
        public List<Product> FeaturedProducts { get; set; } = new();
        public List<Category> TopCategories { get; set; } = new();
    }
}