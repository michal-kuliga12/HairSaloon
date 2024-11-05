using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.Models;

public class Appointment
{
	[Required]
	public int Id { get; set; }
	[Required]
	public int ServiceId { get; set; }
    [ForeignKey("Id")]
    public Service Service { get; set; }
    //public int UserId { get; set; }
    //[ForeignKey("UserId")]
    //public User User { get; set; }
    public DateTime Date { get; set; }
}
