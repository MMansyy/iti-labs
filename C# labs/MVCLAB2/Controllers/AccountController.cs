using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCLAB2.Models;
using MVCLAB2.Models.ViewModels;
using MVCLAB2.Repos;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCLAB2.Controllers
{
    public class AccountController : Controller
    {

        IEntities<User> userRepo;


        public AccountController(IEntities<User> userRepo)
        {
            this.userRepo = userRepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = userRepo.GetAll(u => u.email == model.email && u.password == model.password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                    return View(model);
                }
                Claim c1 = new Claim(ClaimTypes.Name, user.name);
                Claim c2 = new Claim(ClaimTypes.Email, user.email);
                Claim c3 = new Claim(ClaimTypes.Role, user.userRoles.First().role.name);
                var identity = new ClaimsIdentity(new[] { c1, c2, c3 }, "Cookies");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Cookies", principal);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
    }
}
