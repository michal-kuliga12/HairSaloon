using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Index()
    {
        var appointments = _unitOfWork.Appointments.GetAll();
        return View(appointments);
    }


    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Appointment> appointmentList = _unitOfWork.Appointments.GetAll(includeProperties: "Employee,Service").ToList();
        return Json(new { data = appointmentList });
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

