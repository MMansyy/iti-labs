using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce_Project.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        private string CurrentUserId =>
            User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public AddressController(IAddressService _addressService)
        {
            addressService = _addressService;
        }

        // =============================
        // My Addresses
        // =============================

        [HttpGet]
        public IActionResult Index()
        {
            var addresses = addressService.GetUserAddresses(CurrentUserId);
            return View(addresses);
        }

        // =============================
        // Create
        // =============================

        [HttpGet]
        public IActionResult Create(string? returnUrl = null)
        {
            return View(new AddressVM { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await addressService.CreateAsync(CurrentUserId, model);

            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                return Redirect(model.ReturnUrl);

            return RedirectToAction(nameof(Index));
        }

        // =============================
        // Delete
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string? returnUrl = null)
        {
            try
            {
                await addressService.DeleteAsync(id, CurrentUserId);
            }
            catch { }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Index));
        }
    }
}