using Ecommerce_Project.Services;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce_Project.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        private string CurrentUserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        private string CurrentUserRole =>
            User.FindFirstValue(ClaimTypes.Role)!;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        // =============================
        // My Orders
        // =============================

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetUserOrdersAsync(CurrentUserId);
            return View(orders);
        }

        // =============================
        // Checkout
        // =============================

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await orderService.GetCheckoutVMAsync(CurrentUserId);

            if (!model.CartItems.Any())
                return RedirectToAction("Index", "Cart");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CheckOutVM model)
        {
            if (!ModelState.IsValid)
            {
                var freshModel = await orderService.GetCheckoutVMAsync(CurrentUserId);
                model.Addresses = freshModel.Addresses;
                model.CartItems = freshModel.CartItems;
                return View(model);
            }

            try
            {
                await orderService.CreateOrderAsync(CurrentUserId, model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var freshModel = await orderService.GetCheckoutVMAsync(CurrentUserId);
                model.Addresses = freshModel.Addresses;
                model.CartItems = freshModel.CartItems;
                return View(model);
            }
        }

        // =============================
        // Order Details
        // =============================

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await orderService.GetOrderDetailsAsync(id, CurrentUserId, CurrentUserRole);
            if (order == null)
                return NotFound();

            return View(order);
        }

        // =============================
        // Edit Status (Admin)
        // =============================

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await orderService.GetOrderDetailsAsync(id, CurrentUserId, CurrentUserRole);
            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, int orderStatus)
        {
            try
            {
                await orderService.UpdateOrderStatusAsync(id, orderStatus);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var order = await orderService.GetOrderDetailsAsync(id, CurrentUserId, CurrentUserRole);
                return View(order);
            }
        }
    }
}
