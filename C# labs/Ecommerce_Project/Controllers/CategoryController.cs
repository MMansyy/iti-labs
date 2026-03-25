using Ecommerce_Project.Models;
using Ecommerce_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;


        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }


        public IActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = categoryService.GetCategory(id);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (!ModelState.IsValid)
                return View();
            await categoryService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryService.GetCategory(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await categoryService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
