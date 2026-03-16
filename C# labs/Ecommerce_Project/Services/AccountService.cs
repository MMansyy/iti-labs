using Ecommerce_Project.Models;
using Ecommerce_Project.Views.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountService(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterVM model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Customer");
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginVM model)
        {
            return await signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                false
            );
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}