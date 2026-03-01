using Microsoft.AspNetCore.Mvc;

namespace MVCLab1.Controllers
{
    public class TestController : Controller
    {
        public ViewResult display()
        {
            return View();
        }
    }
}
