using Ecommerce_Project.Models;
using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CheckOutVM> GetCheckoutVMAsync(string userId);
        Task CreateOrderAsync(
            string userId,
            CheckOutVM model
        );

        Task<List<Order>> GetUserOrdersAsync(string userId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderDetailsAsync(int orderId, string currentUserId, string currentUserRole);
        Task UpdateOrderStatusAsync(int orderId, int status);
    }
}