using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        //IEnumerable<ApplicationUser> employees = _db.Users.ToList(); // TODO - możliwa zamiana wszystkich IdentityUser na ApplicationUser?
        IEnumerable<ApplicationUser> employees = await _userManager.GetUsersInRoleAsync("Employee"); // Możliwe usunięcie wszystkich rekordów z bazy danych
        CombinedAppointmentVM appointmentVM = new()
        {
            Services = services,
            Employees = employees,
        };
        return View(appointmentVM);
    }

    [HttpPost, ActionName("Create")]
    public IActionResult Create(CombinedAppointmentVM obj)
    {
        Appointment appointment = new()
        {
            ServiceId = 1,
            EmployeeId = obj.Appointment.EmployeeId,
            CustomerPhoneNumber = 111222333,
            CustomerEmail = "Dummy@gmail.com",
            CustomerFirstName = "Test",
            CustomerLastName = "Test",
            Date = obj.Appointment.Date,
        };
        _unitOfWork.Appointments.Add(appointment);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }

    //public IActionResult Create()
    //{
    //    return View();
    //}
}