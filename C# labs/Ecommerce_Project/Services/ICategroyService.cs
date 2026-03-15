using Ecommerce_Project.Models;

namespace Ecommerce_Project.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetCategory(int id);

        Task Create(Category model);

        Task Update(Category model);


        Task Delete(int id);
    }
}
