using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class CatalogController : Controller
{
    private readonly ICatalogService catalogService;

    public CatalogController(ICatalogService _catalogService)
    {
        catalogService = _catalogService;
    }

    public IActionResult Index(CatalogVM model)
    {
        var result = catalogService.GetCatalog(model);
        return View(result);
    }

    public IActionResult Details(int id)
    {
        var model = catalogService.GetProductDetails(id);

        if (model == null)
            return NotFound();

        return View(model);
    }
}