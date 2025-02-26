using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HairSaloonWeb.Areas.Customer.Controllers;

[Area("Admin")]
public class AdminAppointmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _db;

    public AdminAppointmentController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var appointments = _unitOfWork.Appointments.GetAll();
        return View(appointments);
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null || id == 0)
            RedirectToAction("Index");

        Appointment appointment = _unitOfWork.Appointments.Get(x => x.Id == id, includeProperties: "Employee,Service");

        AppointmentVM vm = new(appointment);
        vm.Service = appointment.Service;
        vm.Employee = appointment.Employee;

        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id == 0)
            RedirectToAction("Index");

        Appointment appointment = _unitOfWork.Appointments.Get(x => x.Id == id, includeProperties: "Employee,Service");
        IEnumerable<Service> services = _unitOfWork.Services.GetAll();
        IEnumerable<ApplicationUser> employees = await _userManager.GetUsersInRoleAsync("Employee");

        ViewBag.Services = services.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();

        ViewBag.Employees = employees.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = $"{s.FirstName} {s.LastName}"
        }).ToList();

        ViewBag.AvailableHours = GetAvailableHoursList(appointment.Date, appointment.EmployeeId);

        AppointmentVM vm = new(appointment);
        vm.Service = appointment.Service;
        vm.Employee = appointment.Employee;

        return View(vm);
    }

    [HttpPost]
    public IActionResult Update(Appointment appointment, string date, string time)
    {
        if (ModelState.IsValid)
        {
            DateTime dateTime = DateTime.Parse($"{date} {time}");
            appointment.Date = dateTime;
            _unitOfWork.Appointments.Update(appointment);
            _unitOfWork.Save();

            TempData["success"] = "Appointment created successfully";
            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");
    }


    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Appointment> appointmentList = _unitOfWork.Appointments.GetAll(includeProperties: "Employee,Service").ToList();
        return Json(new { data = appointmentList });
    }

    [HttpGet]
    public IEnumerable<string> GetAvailableHoursList(DateTime? date, string employeeId)
    {
        IEnumerable<Appointment> appointments = _unitOfWork.Appointments.GetAll(
            e => e.EmployeeId == employeeId && EF.Functions.DateDiffDay(e.Date, date) == 0);

        var occupiedHours = appointments.Select(a => a.Date.ToString("HH:mm"));
        IEnumerable<string> hours = new List<string>
        {
            "08:00", "08:30", "09:00","09:30",
            "10:00", "10:30","11:00","11:30",
            "12:00","12:30","13:00","13:30",
            "14:00","14:30","15:00"
        };
        IEnumerable<string> availableHours = hours.Except(occupiedHours);
        return availableHours.ToList();
    }


    [HttpGet]
    public IActionResult GetAvailableHours(DateTime? date, string employeeId)
    {
        IEnumerable<string> availableHours = GetAvailableHoursList(date, employeeId);
        return Json(new { data = availableHours });
    }


    [HttpDelete, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
        Appointment? appointmentFromDb = _unitOfWork.Appointments.Get(s => s.Id == id);

        if (appointmentFromDb == null)
            return Json(new { success = false, message = "Wystąpił problem usuwania" });

        _unitOfWork.Appointments.Remove(appointmentFromDb);
        _unitOfWork.Save();

        return Json(new { success = true, message = "Pomyślnie usunięto element" });
    }

    #endregion
}

