using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairSaloon.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class BlogVM
{
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
    public string[]? Images { get; set; }
    [Required]
    public DateOnly PublicationDate { get; set; }
}