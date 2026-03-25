using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IOrderService orderService;

        public AdminController(IAdminService _adminService, IOrderService _orderService)
        {
            adminService = _adminService;
            orderService = _orderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await adminService.GetDashboardAsync();
            return View(model);
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await orderService.GetAllOrdersAsync();
            return View(orders);
        }
    }
}