using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HairSaloon.Models.ViewModels;

public class ApplicationUserVM
{
    [Required]
    [ValidateNever]
    public string Id { get; set; }
    [ValidateNever]
    [Display(Name = "Adres email")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Imie")]
    [StringLength(20)]
    public string FirstName { get; set; }
    [Required]
    [Display(Name = "Nazwisko")]
    [StringLength(20)]
    public string LastName { get; set; }
    [Required]
    public string Role { get; set; }

    public ApplicationUserVM() { }
    public ApplicationUserVM(ApplicationUser obj)
    {
        Id = obj.Id;
        Email = obj.Email;
        FirstName = obj.FirstName;
        LastName = obj.LastName;
        Role = obj.Role;
    }
}

