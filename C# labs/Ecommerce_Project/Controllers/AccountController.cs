using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IOrderService orderService;
        private readonly IAddressService addressService;

        private string CurrentUserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public AccountController(
            IAccountService _accountService,
            IOrderService _orderService,
            IAddressService _addressService)
        {
            accountService = _accountService;
            orderService = _orderService;
            addressService = _addressService;
        }

        // =============================
        // Register
        // =============================

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.RegisterAsync(model);

                if (result.Succeeded)
                {
                    await accountService.LoginAsync(new LoginVM
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RememberMe = false
                    });

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // =============================
        // Login
        // =============================

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountService.LoginAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Email or Password");
            }

            return View(model);
        }

        // =============================
        // Logout
        // =============================

        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();
            return RedirectToAction("Login");
        }

        // =============================
        // Access Denied
        // =============================

        public IActionResult AccessDenied()
        {
            return View();
        }

        // =============================
        // Settings (Orders + Addresses)
        // =============================

        [Authorize]
        public async Task<IActionResult> Settings(string tab = "orders")
        {
            var model = new SettingsVM
            {
                Orders = await orderService.GetUserOrdersAsync(CurrentUserId),
                Addresses = addressService.GetUserAddresses(CurrentUserId),
                ActiveTab = tab
            };

            return View(model);
        }
    }
}