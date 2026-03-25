using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDashboardVM> GetDashboardAsync();
    }
}