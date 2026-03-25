using Ecommerce_Project.Models;
using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services.Interfaces
{
    public interface IAddressService
    {
        List<Address> GetUserAddresses(string userId);
        Task CreateAsync(string userId, AddressVM model);
        Task DeleteAsync(int addressId, string userId);
    }
}