using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IImageService imageService;

    public ProductService(IUnitOfWork _unitOfWork, IImageService _imageService)
    {
        unitOfWork = _unitOfWork;
        imageService = _imageService;
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
        string? imageUrl = model.ImageUrl;

        if (model.ImageFile != null)
        {
            imageUrl = await imageService.UploadImageAsync(model.ImageFile, "images/products");
        }

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            SKU = model.SKU,
            Price = model.Price,
            StockQuantity = model.StockQuantity,
            IsActive = model.IsActive,
            CategoryId = model.CategoryId,
            ImageUrl = imageUrl
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
            ImageUrl = product.ImageUrl,
            Categories = unitOfWork.Categories.GetAll().ToList()
        };
    }

    public async Task Update(ProductVM model)
    {
        var product = unitOfWork.Products
            .GetAll(p => p.ProductId == model.ProductId)
            .FirstOrDefault();

        if (product == null) return;

        if (model.ImageFile != null)
        {
            if (!string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                await imageService.DeleteImageAsync(product.ImageUrl);
            }

            product.ImageUrl = await imageService.UploadImageAsync(model.ImageFile, "images/products");
        }

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
        var product = unitOfWork.Products
            .GetAll(p => p.ProductId == id)
            .FirstOrDefault();

        var hasOrders = unitOfWork.OrderItems
            .GetAll(oi => oi.ProductId == id)
            .Any();

        if (hasOrders)
        {
            throw new InvalidOperationException("Cannot delete product that has associated orders.");
        }

        if (product == null) return;

        if (!string.IsNullOrWhiteSpace(product.ImageUrl))
        {
            await imageService.DeleteImageAsync(product.ImageUrl);
        }

        unitOfWork.Products.Delete(id);
        await unitOfWork.SaveAsync();
    }
}