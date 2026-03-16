using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterVM model);
        Task<SignInResult> LoginAsync(LoginVM model);
        Task LogoutAsync();
    }
}