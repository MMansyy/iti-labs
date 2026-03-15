using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services
{
    public interface ICatalogService
    {
        CatalogVM GetCatalog(CatalogVM model);
        ProductDetailsVM GetProductDetails(int id);
    }
}
