using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Ecommerce_Project.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor http;
        private readonly IUnitOfWork unitOfWork;

        private const string CartKey = "cart";

        public CartService(IHttpContextAccessor httpContextAccessor,
                           IUnitOfWork _unitOfWork)
        {
            http = httpContextAccessor;
            unitOfWork = _unitOfWork;
        }

        // Helpers

        private List<CartItem> GetCart()
        {
            var sessionCart = http.HttpContext!.Session.GetString(CartKey);

            return sessionCart == null
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(sessionCart)!;
        }

        private void SaveCart(List<CartItem> cart)
        {
            http.HttpContext!.Session.SetString(
                CartKey,
                JsonSerializer.Serialize(cart)
            );
        }

        // Methods

        public List<CartItem> GetCartItems()
        {
            return GetCart();
        }

        public void AddToCart(int productId)
        {
            var product = unitOfWork.Products
                .GetAll(p => p.ProductId == productId)
                .FirstOrDefault();

            if (product == null) return;

            var cart = GetCart();

            var existingItem = cart
                .FirstOrDefault(c => c.ProductId == productId);

            if (existingItem != null)
                existingItem.Quantity++;
            else
                cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
                cart.Remove(item);

            SaveCart(cart);
        }

        public void UpdateCart(int productId, int quantity)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item == null) return;

            if (quantity <= 0)
                cart.Remove(item);
            else
                item.Quantity = quantity;

            SaveCart(cart);
        }

        public void ClearCart()
        {
            http.HttpContext!.Session.Remove(CartKey);
        }
    }
}