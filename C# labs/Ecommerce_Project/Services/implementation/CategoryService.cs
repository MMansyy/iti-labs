using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Services.Interfaces;

namespace Ecommerce_Project.Services.implementation
{
    public class CategoryService : ICategoryService
    {

        IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task Create(Category model)
        {
            var category = new Category
            {
                Name = model.Name,
                ParentCategoryId = model.ParentCategoryId
            };
            unitOfWork.Categories.Add(category);
            await unitOfWork.SaveAsync();

        }

        public async Task Delete(int id)
        {
            var category = unitOfWork.Categories
                .GetAll(c => c.CategoryId == id)
                .FirstOrDefault();
            if (category == null) return;
            unitOfWork.Categories.Delete(id);
            await unitOfWork.SaveAsync();
        }

        public List<Category> GetAll()
        {
            return unitOfWork.Categories.GetAll().ToList();

        }

        public Category GetCategory(int id)
        {
            var category = unitOfWork.Categories.GetAll(c => c.CategoryId == id).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            return category;
        }
   

        public async Task Update(Category model)
        {
            var category = unitOfWork.Categories.GetAll(c => c.CategoryId == model.CategoryId).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            category.Name = model.Name;
            category.ParentCategoryId = model.ParentCategoryId;
            unitOfWork.Categories.Update(category);
            await unitOfWork.SaveAsync();
        }
    }
}
