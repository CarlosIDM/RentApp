using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RentApp.BussinesLayer.Login;
using RentApp.Entities.Tables;
using RentApp.Models.Login;
using System.Security.Claims;

namespace RentApp.Controllers
{
    public class LoginController : Controller
    {
        private LoginBL login { get; set; }
        public LoginController(LoginBL login)
        {
            this.login = login;
        }

        public IActionResult Index()
        {
            return View(login.Init());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel log)
        {
            var result = await login.LoginAsync(log);
            if(result != null && result.Result != null)
            {
				var userClaims = new List<Claim>()
				{
					new Claim("Name", result.Result.Name),
					new Claim("LastName", result.Result.LastName),
					new Claim("RolName", result.Result.RolName),
					new Claim("UserId", result.Result.UserId.ToString()),
					new Claim("Token", result.Result.Token),
					new Claim("Token", result.Result.DateExpiredToken.ToString("dd/MM/yyyy hh:mm tt"))
				 };

				var userIdentity = new ClaimsIdentity(userClaims, "User");

				var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                if(HttpContext != null) 
                {
					HttpContext.SignInAsync(userPrincipal);
					//si son datos validos
					return View(login.Init());
				}
				return View(login.Init());
			}
            else
            {
                ModelState.AddModelError("CredentialError", result?.Message);
                return View(login.Init());
            }          
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
