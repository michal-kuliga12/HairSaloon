using HairSaloon.DataAccess.Repository.IRepository;
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

    public IActionResult Create() 
    {
        return View();
    }


}
