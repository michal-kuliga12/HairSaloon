using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Controllers;

public class AppointmentController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Create()
	{
		return View();	
	}
}
