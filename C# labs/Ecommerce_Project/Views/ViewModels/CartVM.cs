using Ecommerce_Project.Models;

namespace Ecommerce_Project.Views.ViewModels
{
    public class CartVM
    {
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();

        public decimal TotalPrice => CartItems.Sum(c => c.Price * c.Quantity);

    }
}
