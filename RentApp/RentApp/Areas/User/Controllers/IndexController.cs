using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentApp.Areas.User.Controllers
{
	[Area("User")]
	public class IndexController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
