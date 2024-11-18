using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.Models;

public class Employee
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    //public int DurationInMinutes { get; set; }
}
