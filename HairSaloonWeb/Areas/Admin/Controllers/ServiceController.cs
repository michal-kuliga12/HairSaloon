using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using HairSaloon.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
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

	public IActionResult Update(int? id)
	{
		if (id == null || id == 0)
			RedirectToAction("Create");

		Service obj = _unitOfWork.Services.Get(u => u.Id == id);
		ServiceVM serviceVM = new ServiceVM(obj);
		return View(serviceVM);
	}

	[HttpPost, ActionName("Update")]
	public IActionResult Update(Service obj)
	{
		if (ModelState.IsValid)
		{
			_unitOfWork.Services.Update(obj);
			_unitOfWork.Save();
			TempData["success"] = "Category edited successfully";
			return RedirectToAction("Index");
		}
		return View();
	}

	#region API CALLS

	[HttpGet]
	public IActionResult GetAll()
	{
		List<Service> serviceList = _unitOfWork.Services.GetAll().ToList();
		return Json(new { data = serviceList });
	}

	[HttpDelete, ActionName("Delete")]
	public IActionResult Delete(int id)
	{
		Service? serviceFromDb = _unitOfWork.Services.Get(s => s.Id == id);

		if (serviceFromDb == null)
			return Json(new { success = false, message = "Wystąpił problem usuwania" });

		_unitOfWork.Services.Remove(serviceFromDb);
		_unitOfWork.Save();

		return Json(new { success = true, message = "Pomyślnie usunięto element" });
	}

	#endregion

}
