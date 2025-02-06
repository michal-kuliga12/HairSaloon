using System.Diagnostics;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Areas.Customer.Controllers;
[Area("Customer")]
public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BlogController(ILogger<BlogController> logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IActionResult Index()
    {
        IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAll();
        return View(blogs);
    }

    [HttpGet("Article/{id}")]
    public IActionResult Article(int id)
    {
        Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id);
        return View(blog);
    }


    [HttpGet("Upsert/{id}")]
    public IActionResult Upsert(int id)
    {
        Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id);
        return View(blog);
    }

    [HttpPost("Upsert/{id}")]
    //public IActionResult Upsert([FromBody] Blog blogVM) - Używany do jsona
    public IActionResult Upsert(Blog blogVM)
    {
        if (ModelState.IsValid)
        {
            Blog blog = new()
            {
                Title = blogVM.Title,
                Content = blogVM.Content,
                EmployeeId = blogVM.EmployeeId,
                Images = blogVM.Images,
                PublicationDate = new DateOnly()
            };

            if (blogVM.Id == 0)
            {
                _unitOfWork.Blogs.Add(blog);
            }
            else
            {
                _unitOfWork.Blogs.Update(blog);
            };

            _unitOfWork.Save();
            TempData["success"] = "Blog added/updated successfully";

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
