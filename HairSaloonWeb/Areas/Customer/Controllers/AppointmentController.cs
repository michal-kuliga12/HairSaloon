using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Areas.Customer.Controllers;
[Area("Customer")]
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
