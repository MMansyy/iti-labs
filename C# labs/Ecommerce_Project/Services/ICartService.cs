using Ecommerce_Project.Models;

namespace Ecommerce_Project.Services
{
    public interface ICartService
    {
        List<CartItem> GetCartItems();

        void AddToCart(int productId);

        void RemoveFromCart(int productId);

        void UpdateCart(int productId, int quantity);

        void ClearCart();
    }
}