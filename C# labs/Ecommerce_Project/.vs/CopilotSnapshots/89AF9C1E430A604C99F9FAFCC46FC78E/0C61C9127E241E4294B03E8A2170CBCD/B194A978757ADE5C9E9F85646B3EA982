using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Views.ViewModels;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;

    public ProductService(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }

    public List<Product> GetAll()
    {
        return unitOfWork.Products
            .GetAll(null, "Category")
            .ToList();
    }

    public ProductVM GetCreateVM()
    {
        return new ProductVM
        {
            Categories = unitOfWork.Categories.GetAll().ToList()
        };
    }

    public async Task Create(ProductVM model)
    {
        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            SKU = model.SKU,
            Price = model.Price,
            StockQuantity = model.StockQuantity,
            IsActive = model.IsActive,
            CategoryId = model.CategoryId
        };

        unitOfWork.Products.Add(product);
        await unitOfWork.SaveAsync();
    }

    public ProductVM GetEditVM(int id)
    {
        var product = unitOfWork.Products
            .GetAll(p => p.ProductId == id)
            .FirstOrDefault();

        if (product == null) return null;

        return new ProductVM
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            SKU = product.SKU,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            IsActive = product.IsActive,
            CategoryId = product.CategoryId,
            Categories = unitOfWork.Categories.GetAll().ToList()
        };
    }

    public async Task Update(ProductVM model)
    {
        var product = unitOfWork.Products
            .GetAll(p => p.ProductId == model.ProductId)
            .FirstOrDefault();

        if (product == null) return;

        product.Name = model.Name;
        product.Description = model.Description;
        product.SKU = model.SKU;
        product.Price = model.Price;
        product.StockQuantity = model.StockQuantity;
        product.IsActive = model.IsActive;
        product.CategoryId = model.CategoryId;

        unitOfWork.Products.Update(product);
        await unitOfWork.SaveAsync();
    }

    public Product GetDeleteProduct(int id)
    {
        return unitOfWork.Products
            .GetAll(p => p.ProductId == id, "Category")
            .FirstOrDefault();
    }

    public async Task Delete(int id)
    {
        unitOfWork.Products.Delete(id);
        await unitOfWork.SaveAsync();
    }
}