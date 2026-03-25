using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var model = new HomeVM
            {
                ProductsCount = unitOfWork.Products.GetAll(p => p.IsActive).Count(),
                CategoriesCount = unitOfWork.Categories.GetAll().Count(),
                FeaturedProducts = unitOfWork.Products
                    .GetAll(p => p.IsActive, "Category")
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(6)
                    .ToList(),
                TopCategories = unitOfWork.Categories
                    .GetAll()
                    .OrderBy(c => c.Name)
                    .Take(8)
                    .ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
