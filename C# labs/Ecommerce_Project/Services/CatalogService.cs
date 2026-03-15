using Ecommerce_Project.Repositories;
using Ecommerce_Project.Services;
using Ecommerce_Project.Views.ViewModels;

public class CatalogService : ICatalogService
{
    private readonly IUnitOfWork unitOfWork;

    public CatalogService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public CatalogVM GetCatalog(CatalogVM model)
    {
        var query = unitOfWork.Products.GetAll(null, "Category");
        var categories = unitOfWork.Categories.GetAll();

        int pageSize = 10;

        // Filter
        if (model.CategoryId != null)
        {
            query = query.Where(p => p.CategoryId == model.CategoryId);
        }

        // Search
        if (!string.IsNullOrEmpty(model.QuerySearch))
        {
            query = query.Where(p =>
                p.Name.Contains(model.QuerySearch) ||
                (p.Description != null &&
                 p.Description.Contains(model.QuerySearch)));
        }

        // Sort
        query = model.SortBy switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "name_desc" => query.OrderByDescending(p => p.Name),
            "name_asc" => query.OrderBy(p => p.Name),
            _ => query.OrderBy(p => p.ProductId)
        };

        // Pagination
        model.TotalItems = query.Count();

        model.TotalPages =
            (int)Math.Ceiling((double)model.TotalItems / pageSize);

        model.Products = query
            .Skip((model.PageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        model.Categories = categories.ToList();

        return model;
    }

    public ProductDetailsVM GetProductDetails(int id)
    {
        var product = unitOfWork.Products
            .GetAll(p => p.ProductId == id, "Category")
            .FirstOrDefault();

        if (product == null)
            return null;

        var relatedProducts = unitOfWork.Products
            .GetAll(p => p.CategoryId == product.CategoryId &&
                         p.ProductId != id, "Category")
            .Take(4)
            .ToList();

        return new ProductDetailsVM
        {
            Product = product,
            RelatedProducts = relatedProducts
        };
    }
}