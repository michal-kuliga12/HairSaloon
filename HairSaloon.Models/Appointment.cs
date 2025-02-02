using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HairSaloon.Models;

public class Appointment
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [ForeignKey("ServiceId")]
    [ValidateNever]
    public Service Service { get; set; }

    [Display(Name = "Employee Id")]
    [Required]
    public string EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [ValidateNever]
    public ApplicationUser Employee { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public int CustomerPhoneNumber { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string CustomerEmail { get; set; }

    [Required]
    [StringLength(20)]
    public string CustomerFirstName { get; set; }


    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
}

public class AppointmentRequest
{
    public DateTime Date { get; set; }
    public string EmployeeId { get; set; }
}