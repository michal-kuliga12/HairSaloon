using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HairSaloon.Models.ViewModels;

public class AppointmentVM
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Usługa jest wymagana")]
    public int ServiceId { get; set; }

    [ForeignKey("ServiceId")]
    [ValidateNever]
    public Service Service { get; set; }

    [Display(Name = "Employee Id")]
    [Required(ErrorMessage = "Id pracownika jest wymagane")]
    public string EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [ValidateNever]
    public ApplicationUser Employee { get; set; }

    [Required(ErrorMessage = "Numer telefonu jest wymagany")]
    [DataType(DataType.PhoneNumber)]
    //[RegularExpression(@"^(?<code>\+?\d{1,3})[-\s]{0,}(?<number>\(?\d{3}\)?[-\s]{0,}\d{3}[-\s]{0,}\d{2}[-\s]{0,}\d{2})$", ErrorMessage = "Nieprawidłowy numer telefonu")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Nieprawidłowy numer telefonu")]
    public string CustomerPhoneNumber { get; set; }

    [Required(ErrorMessage = "Adres e-mail jest wymagany")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Nieprawidłowy adres e-mail")]
    public string CustomerEmail { get; set; }

    [Required(ErrorMessage = "Imie jest wymagane")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Nieprawidłowe imie")]
    public string CustomerFirstName { get; set; }


    [Required(ErrorMessage = "Data i godzina jest wymagana")]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }

    public AppointmentVM() { }
    public AppointmentVM(Appointment obj)
    {
        Id = obj.Id;
        ServiceId = obj.ServiceId;
        EmployeeId = obj.EmployeeId;
        CustomerPhoneNumber = obj.CustomerPhoneNumber;
        CustomerEmail = obj.CustomerEmail;
        CustomerFirstName = obj.CustomerFirstName;
        Date = obj.Date;
    }
}
