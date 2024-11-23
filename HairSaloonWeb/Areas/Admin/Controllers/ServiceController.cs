using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

    public IActionResult Create()
        => View(new ServiceVM());

    [HttpPost, ActionName("Create")]
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

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll() {
        List<Service> serviceList = _unitOfWork.Services.GetAll().ToList();
        return Json(new {data = serviceList});
    }

    [HttpDelete, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
        Service? serviceFromDb = _unitOfWork.Services.Get(s => s.Id == id);

        if (serviceFromDb == null)
            return Json(new { success = false , message = "Wystąpił problem usuwania"});

        _unitOfWork.Services.Delete(serviceFromDb);
        _unitOfWork.Save();

        return Json(new { success = true, message = "Pomyślnie usunięto element" });
    }

    #endregion

}
