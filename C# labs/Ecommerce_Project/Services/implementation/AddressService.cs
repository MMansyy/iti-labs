using Ecommerce_Project.Models;
using Ecommerce_Project.Repositories;
using Ecommerce_Project.Services.Interfaces;
using Ecommerce_Project.Views.ViewModels;

namespace Ecommerce_Project.Services.implementation
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public List<Address> GetUserAddresses(string userId)
        {
            return unitOfWork.Addresses
                .GetAll(a => a.UserId == userId)
                .OrderByDescending(a => a.IsDefault)
                .ToList();
        }

        public async Task CreateAsync(string userId, AddressVM model)
        {
            var existingAddresses = unitOfWork.Addresses
                .GetAll(a => a.UserId == userId)
                .ToList();

            // If this is the first address, make it default automatically
            bool isDefault = model.IsDefault || !existingAddresses.Any();

            // If marked default, unset any existing default
            if (isDefault)
            {
                foreach (var existing in existingAddresses.Where(a => a.IsDefault))
                {
                    existing.IsDefault = false;
                    unitOfWork.Addresses.Update(existing);
                }
            }

            var address = new Address
            {
                UserId = userId,
                Country = model.Country,
                City = model.City,
                Street = model.Street,
                Zip = model.Zip,
                IsDefault = isDefault
            };

            unitOfWork.Addresses.Add(address);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int addressId, string userId)
        {
            var address = unitOfWork.Addresses
                .GetAll(a => a.AddressId == addressId && a.UserId == userId)
                .FirstOrDefault();

            if (address == null)
                throw new Exception("Address not found");

            unitOfWork.Addresses.Delete(addressId);
            await unitOfWork.SaveAsync();
        }
    }
}