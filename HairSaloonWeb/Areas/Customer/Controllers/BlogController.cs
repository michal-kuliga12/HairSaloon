using System.Diagnostics;
using System.Security.Claims;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using Microsoft.AspNetCore.Authorization;
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


    [Authorize]
    [HttpGet("Upsert/{id?}")]
    public IActionResult Upsert(int? id)
    {
        BlogVM blogVM = new();

        if (id == 0 || id == null)
        {
            return View(blogVM);
        }
        else
        {
            Blog blog = _unitOfWork.Blogs.Get(x => x.Id == id, includeProperties: "Images");
            blogVM.Id = id;
            blogVM.Title = blog.Title;
            blogVM.Content = blog.Content;
            blogVM.EmployeeId = blog.EmployeeId;
            blogVM.Images = blog.Images;
            blogVM.PublicationDate = blog.PublicationDate;
            return View(blogVM);
        }
    }

    [Authorize]
    [HttpPost("Upsert/{id}")]
    public IActionResult Upsert(int id, BlogVM blogVM, IFormFile? image)
    {
        if (!ModelState.IsValid)
        {
            return View(blogVM);
        }

        var blog = new Blog
        {
            Id = id,
            Title = blogVM.Title,
            Content = blogVM.Content,
            EmployeeId = GetUserId(),
            Images = blogVM.Images,
            PublicationDate = blogVM.PublicationDate
        };

        if (id == 0)
        {
            _unitOfWork.Blogs.Add(blog);
        }
        else
        {
            _unitOfWork.Blogs.Update(blog);
        }
        _unitOfWork.Save();

        if (image != null)
        {
            RemoveOldBlogImages(blog);
            SaveBlogImage(blog, image);
            _unitOfWork.Blogs.Update(blog);
            _unitOfWork.Save();
        }

        TempData["success"] = "Blog added/updated successfully";
        return RedirectToAction("Index");
    }

    private void SaveBlogImage(Blog blog, IFormFile image)
    {
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        string blogPath = Path.Combine(wwwRootPath, "images", "Blog");

        if (!Directory.Exists(blogPath))
        {
            Directory.CreateDirectory(blogPath);
        }

        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        string finalPath = Path.Combine(blogPath, fileName);

        using (var fileStream = new FileStream(finalPath, FileMode.Create))
        {
            image.CopyTo(fileStream);
        }

        var blogImage = new BlogImage
        {
            ImageUrl = $"/images/Blog/{fileName}",
            BlogId = blog.Id
        };

        blog.Images ??= new List<BlogImage>();
        blog.Images.Clear();
        blog.Images.Add(blogImage);
    }

    private void RemoveOldBlogImages(Blog blog)
    {
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        IEnumerable<BlogImage> blogImages = _unitOfWork.BlogImages.GetAll(x => x.BlogId == blog.Id);
        foreach (var blogImage in blogImages)
        {
            string oldImagePath = Path.Combine(wwwRootPath, blogImage.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }
        _unitOfWork.BlogImages.RemoveRange(blogImages);
    }

    //[Authorize]
    //[HttpPost("Upsert/{id}")]
    //public IActionResult Upsert(int id, BlogVM blogVM, IFormFile image)
    //{
    //    Blog blog = new Blog()
    //    {
    //        Id = id,
    //        Title = blogVM.Title,
    //        Content = blogVM.Content,
    //        EmployeeId = GetUserId(),
    //        Images = blogVM.Images,
    //        PublicationDate = blogVM.PublicationDate,
    //    };

    //    if (ModelState.IsValid)
    //    {
    //        if (blog.Id == 0)
    //        {
    //            _unitOfWork.Blogs.Add(blog);
    //        }
    //        else
    //        {
    //            _unitOfWork.Blogs.Update(blog);
    //        };

    //        _unitOfWork.Save();

    //        string wwwRootPath = _webHostEnvironment.WebRootPath;
    //        if (image != null)
    //        {
    //            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
    //            string blogPath = @"images\Blog\";
    //            string finalPath = Path.Combine(wwwRootPath, blogPath);

    //            if (!Directory.Exists(finalPath))
    //                Directory.CreateDirectory(finalPath);

    //            using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
    //            {
    //                image.CopyTo(fileStream);
    //            }

    //            BlogImage blogImage = new()
    //            {
    //                ImageUrl = @"\" + blogPath + @"\" + fileName,
    //                BlogId = id
    //            };

    //            if (blog.Images == null)
    //                blog.Images = new List<BlogImage>();

    //            if (blog.Images.Count >= 1)
    //            {
    //                blog.Images.Clear();
    //            }
    //            blog.Images.Add(blogImage);

    //            _unitOfWork.Blogs.Update(blog);
    //            _unitOfWork.Save();
    //        }

    //        TempData["success"] = "Blog added/updated successfully";
    //        return RedirectToAction("Index");
    //    }
    //    else
    //    {
    //        return View(blogVM);
    //    }

    //}

    private string GetUserId()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        return userId;
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
