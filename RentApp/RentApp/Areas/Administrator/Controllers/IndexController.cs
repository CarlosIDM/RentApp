using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentApp.Areas.Administrator.Controllers
{
	[Area("Administrator")]
	public class IndexController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
