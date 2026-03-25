using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService _cartService)
        {
            cartService = _cartService;
        }

        public IActionResult Index()
        {
            var cartItems = cartService.GetCartItems();
            var cart = new CartVM
            {
                CartItems = cartItems
            };
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            cartService.AddToCart(productId);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Delete(int productId)
        {
            cartService.RemoveFromCart(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int productId, int quantity)
        {
            cartService.UpdateCart(productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            cartService.ClearCart();
            return RedirectToAction(nameof(Index));
        }
    }
}