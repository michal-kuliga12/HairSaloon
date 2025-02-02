using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HairSaloonWeb.Areas.Customer.Controllers;

[Area("Customer")]
public class AppointmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    //private readonly UserManager<ApplicationUser> _userManager; TODO
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _db;

    public AppointmentController(IUnitOfWork unitOfWork, /*UserManager<ApplicationUser> userManager,*/UserManager<ApplicationUser> userManager, ApplicationDbContext db)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Service> services = _unitOfWork.Services.GetAll();
        IEnumerable<ApplicationUser> employees = await _userManager.GetUsersInRoleAsync("Employee");
        ViewBag.Services = services;
        ViewBag.Employees = employees;
        AppointmentVM vm = new AppointmentVM();
        return View(vm);
    }

    [HttpPost, ActionName("Create")]
    public IActionResult Create(Appointment obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Appointments.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Appointment created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    #region API CALLS
    [HttpPost]
    public IActionResult GetAvailableHours([FromBody] AppointmentRequest request)
    {
        IEnumerable<Appointment> appointments = _unitOfWork.Appointments.GetAll(
            e => e.EmployeeId == request.EmployeeId && EF.Functions.DateDiffDay(e.Date, request.Date) == 0);

        var hours = appointments.Select(a => a.Date.ToString("HH:mm"));

        return Json(new { data = hours });
    }

    #endregion
}

