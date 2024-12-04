using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSaloon.Models;

public class Appointment
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int ServiceId { get; set; }
    [ForeignKey("Id")]
    public Service Service { get; set; }
    public DateTime Date { get; set; }
}
