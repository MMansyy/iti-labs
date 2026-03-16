using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services
{
    public interface IAdminService
    {
        Task<AdminDashboardVM> GetDashboardAsync();
    }
}