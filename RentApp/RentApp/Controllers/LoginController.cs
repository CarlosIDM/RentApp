using Microsoft.AspNetCore.Mvc;

namespace RentApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }
    }
}
