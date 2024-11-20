using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ServiceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }
    public IActionResult Index()
    {
        var services = _unitOfWork.Services.GetAll();
        return View(services);
    }

    public IActionResult Create(Service obj) 
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Services.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id) 
    {
        if (id == null || id == 0)
            return NotFound();

        Service serviceFromDb = _unitOfWork.Services.Get(s => s.Id == id);

        if (serviceFromDb == null)
            return NotFound();

        return View(serviceFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
        Service? serviceFromDb = _unitOfWork.Services.Get(s => s.Id == id);
        
        if (serviceFromDb == null)
            return NotFound();

        _unitOfWork.Services.Delete(serviceFromDb);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }

}
