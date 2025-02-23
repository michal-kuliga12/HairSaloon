using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HairSaloon.Models;

public class Blog
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Display(Name = "Employee Id")]
    [Required]
    public string EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [Display(Name = "Author")]
    [ValidateNever]
    public ApplicationUser Employee { get; set; }
    [ValidateNever]
    public List<BlogImage> Images { get; set; }
    [Required]
    public DateOnly PublicationDate { get; set; }
}
