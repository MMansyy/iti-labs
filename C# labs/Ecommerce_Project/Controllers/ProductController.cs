using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IProductService productService;
    

    public ProductController(IProductService _productService)
    {
        productService = _productService;
    }

    public IActionResult Index()
    {
        var products = productService.GetAll();
        return View(products);
    }

    public IActionResult Create()
    {
        return View(productService.GetCreateVM());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductVM model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = productService.GetCreateVM().Categories;
            return View(model);
        }

        try
        {
            await productService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(nameof(model.ImageFile), ex.Message);
            model.Categories = productService.GetCreateVM().Categories;
            return View(model);
        }
    }

    public IActionResult Edit(int id)
    {
        var model = productService.GetEditVM(id);
        if (model == null) return NotFound();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductVM model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = productService.GetCreateVM().Categories;
            return View(model);
        }

        try
        {
            await productService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(nameof(model.ImageFile), ex.Message);
            model.Categories = productService.GetCreateVM().Categories;
            return View(model);
        }
    }

    public IActionResult Delete(int id)
    {
        var product = productService.GetDeleteProduct(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            var product = productService.GetDeleteProduct(id);

            return View(product);
        }
    }
}