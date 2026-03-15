using Ecommerce_Project.Views.ViewModels;
using Ecommerce_Project.Models;

public interface IProductService
{
    List<Product> GetAll();

    ProductVM GetCreateVM();

    Task Create(ProductVM model);

    ProductVM GetEditVM(int id);

    Task Update(ProductVM model);

    Product GetDeleteProduct(int id);

    Task Delete(int id);
}