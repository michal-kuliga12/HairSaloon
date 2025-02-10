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
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BlogController(ILogger<BlogController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        IEnumerable<Blog> blogs = _unitOfWork.Blogs.GetAll(includeProperties: "Images").ToList();
        return View(blogs);
    }

    [HttpGet("Article/{id}")]
    public IActionResult Article(int id)
    {
        Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id, includeProperties: "Images");
        return View(blog);
    }


    [HttpGet("Upsert/{id?}")]
    public IActionResult Upsert(int id)
    {
        //BlogVM blogVM = new BlogVM();
        //if (id != 0 || id == null)
        //{
        //    Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id);
        //    blogVM.Id = id;
        //    blogVM.Title = blog.Title;
        //    blogVM.Content = blog.Content;
        //    blogVM.EmployeeId = blog.EmployeeId;
        //    blogVM.Images = blog.Images;
        //    blogVM.PublicationDate = blog.PublicationDate;
        //}

        //return View(blogVM);

        if (id == 0 || id == null)
        {
            return View(new Blog());
        }
        else
        {
            Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id, includeProperties: "Images");
            return View(blog);
        }


    }

    [HttpPost("Upsert/{id}")]
    public IActionResult Upsert(int id, Blog blog, IFormFile image)
    {
        if (ModelState.IsValid)
        {
            if (blog.Id == 0)
            {
                _unitOfWork.Blogs.Add(blog);
            }
            else
            {
                _unitOfWork.Blogs.Update(blog);
            };

            _unitOfWork.Save();

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string blogPath = @"images\Blog\";
                string finalPath = Path.Combine(wwwRootPath, blogPath);

                if (!Directory.Exists(finalPath))
                    Directory.CreateDirectory(finalPath);

                using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                BlogImage blogImage = new()
                {
                    ImageUrl = @"\" + blogPath + @"\" + fileName,
                    BlogId = id
                };

                if (blog.Images == null)
                    blog.Images = new List<BlogImage>();

                if (blog.Images.Count >= 1)
                {
                    blog.Images.Clear();
                }
                blog.Images.Add(blogImage);

                _unitOfWork.Blogs.Update(blog);
                _unitOfWork.Save();
            }

            TempData["success"] = "Blog added/updated successfully";
            return RedirectToAction("Index");
        }
        else
        {
            return View(blog);
        }


        //if (ModelState.IsValid)
        //{
        //    Blog blog = new()
        //    {
        //        Id = id,
        //        Title = blogVM.Title,
        //        Content = blogVM.Content,
        //        EmployeeId = blogVM.EmployeeId,
        //        Images = null,
        //        PublicationDate = DateOnly.FromDateTime(DateTime.Today)
        //    };

        //    if (blogVM.Id == 0)
        //    {
        //        _unitOfWork.Blogs.Add(blog);
        //    }
        //    else
        //    {
        //        _unitOfWork.Blogs.Update(blog);
        //    };

        //    _unitOfWork.Save();

        //    string wwwRootPath = _webHostEnvironment.WebRootPath;
        //    if (image != null)
        //    {
        //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        //        string blogPath = @"images\Blog\";
        //        string finalPath = Path.Combine(wwwRootPath, blogPath);

        //        if (!Directory.Exists(finalPath))
        //            Directory.CreateDirectory(finalPath);

        //        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
        //        {
        //            image.CopyTo(fileStream);
        //        }

        //        BlogImage blogImage = new()
        //        {
        //            ImageUrl = @"\" + blogPath + @"\" + fileName,
        //            BlogId = id
        //        };

        //        if (blog.Images == null)
        //            blog.Images = new List<BlogImage>();

        //        blog.Images.Add(blogImage);

        //        _unitOfWork.Blogs.Update(blog);
        //        _unitOfWork.Save();
        //    }

        //    TempData["success"] = "Blog added/updated successfully";
        //    return RedirectToAction("Index");
        //}
        //else
        //{
        //    return View(blogVM);
        //}

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
