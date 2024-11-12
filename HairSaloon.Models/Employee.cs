using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.Models;

public class Service
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
	[Required]
	public string Category { get; set; }
	[Required]
	public int Price { get; set; }
    //public int DurationInMinutes { get; set; }
}
