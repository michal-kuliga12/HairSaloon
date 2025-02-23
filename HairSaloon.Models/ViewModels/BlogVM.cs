using System.ComponentModel.DataAnnotations;
using HairSaloon.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class BlogVM
{
    public int? Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Display(Name = "Employee Id")]
    [ValidateNever]
    public string EmployeeId { get; set; }

    [ValidateNever]
    public List<BlogImage> Images { get; set; }
    [Required]
    public DateOnly PublicationDate { get; set; }

    public BlogVM()
    {
        Id = 0;
        Title = "";
        Content = "";
        Images = new List<BlogImage>();
        PublicationDate = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}

