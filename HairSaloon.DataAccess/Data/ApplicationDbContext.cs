using HairSaloon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        base.OnModelCreating(modelBuilder); // Jest potrzebne jako konfiguracja do IdentityDbContext

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50,DurationInMinutes=60,Description=""},
            new Service { Id = 2, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50,DurationInMinutes=90,Description=""},
            new Service { Id = 3, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50,DurationInMinutes=30,Description=""},
            new Service { Id = 4, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 5, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
            new Service { Id = 6, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
            new Service { Id = 7, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 8, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 9, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
            new Service { Id = 10, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" }
            );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { Id = 1, ServiceId = 1, Date = DateTime.Now },
            new Appointment { Id = 2, ServiceId = 2, Date = DateTime.Now },
            new Appointment { Id = 3, ServiceId = 3, Date = DateTime.Now },
            new Appointment { Id = 4, ServiceId = 4, Date = DateTime.Now }
            );

		modelBuilder.Entity<Employee>().HasData(
			new Employee { Id = 1, Name="Krzysztof", ImageUrl=""},
			new Employee { Id = 2, Name = "Barbara", ImageUrl = "" },
			new Employee { Id = 3, Name = "Piotr" , ImageUrl = "" },
			new Employee { Id = 4, Name = "Michał" , ImageUrl = "" }
			);
	}
}
