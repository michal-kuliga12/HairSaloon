using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HairSaloon.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? ImageUrl { get; set; }

    [NotMapped]
    public string Role { get; set; }
}