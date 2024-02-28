using Microsoft.AspNetCore.Mvc;

namespace RentApp.Controllers
{
	public class AccessDeniedController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
