using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project.Services.implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(IUnitOfWork _unitOfWork, UserManager<ApplicationUser> _userManager)
        {
            unitOfWork = _unitOfWork;
            userManager = _userManager;
        }

        public async Task<AdminDashboardVM> GetDashboardAsync()
        {
            var customers = await userManager.GetUsersInRoleAsync("Customer");

            return new AdminDashboardVM
            {
                TotalProducts = unitOfWork.Products.GetAll().Count(),
                TotalCategories = unitOfWork.Categories.GetAll().Count(),
                TotalOrders = unitOfWork.Orders.GetAll().Count(),
                TotalCustomers = customers.Count,
                TotalRevenue = unitOfWork.Orders.GetAll().Sum(o => o.TotalAmount),
                RecentOrders = unitOfWork.Orders
                    .GetAll(null, "User")
                    .OrderByDescending(o => o.OrderDate)
                    .Take(7)
                    .ToList(),
                LowStockProducts = unitOfWork.Products
                    .GetAll(p => p.StockQuantity <= 5, "Category")
                    .OrderBy(p => p.StockQuantity)
                    .Take(7)
                    .ToList()
            };
        }
    }
}