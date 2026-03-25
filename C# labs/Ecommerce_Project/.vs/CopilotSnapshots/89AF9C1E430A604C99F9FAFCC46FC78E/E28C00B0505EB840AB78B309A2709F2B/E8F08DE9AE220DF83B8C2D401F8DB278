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
            return View(productService.GetCreateVM());

        await productService.Create(model);
        return RedirectToAction(nameof(Index));
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
            return View(productService.GetCreateVM());

        await productService.Update(model);
        return RedirectToAction(nameof(Index));
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
        await productService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}