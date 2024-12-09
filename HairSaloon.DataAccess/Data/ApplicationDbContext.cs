﻿using HairSaloon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairSaloon.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
// Zamienione z DbContext, IdentityDbContext jest funkcjonalnością wymaganą do .NET identity
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Appointment> Appointments { get; set; }
	public DbSet<Service> Services { get; set; }
	public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder); // Jest potrzebne jako konfiguracja do IdentityDbContext

		modelBuilder.Entity<Service>().HasData(
			new Service { Id = 1, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
			new Service { Id = 2, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
			new Service { Id = 3, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 4, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 5, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
			new Service { Id = 6, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
			new Service { Id = 7, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 8, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 9, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 10, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 11, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
			new Service { Id = 12, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
			new Service { Id = 13, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 14, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 15, Name = "Strzyżenie męskie", Category = "Strzyżenie", Price = 50, DurationInMinutes = 60, Description = "" },
			new Service { Id = 16, Name = "Strzyżenie damskie", Category = "Farbowanie", Price = 50, DurationInMinutes = 90, Description = "" },
			new Service { Id = 17, Name = "Farbowanie włosów", Category = "Pakiety", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 18, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 19, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" },
			new Service { Id = 20, Name = "Depilacja", Category = "Pielęgnacja", Price = 50, DurationInMinutes = 30, Description = "" }
			);

		modelBuilder.Entity<Appointment>().HasData(
			new Appointment
			{
				Id = 1,
				ServiceId = 6,
				EmployeeId = "b9fd838c-5e26-49f9-953a-c00e3b34b9da",
				CustomerPhoneNumber = 222666111,
				CustomerFirstName = "Michal",
				CustomerEmail = "test@gmail.com",
				Date = DateTime.Now
			},
			new Appointment
			{
				Id = 2,
				ServiceId = 5,
				EmployeeId = "ae06c675-dbfb-4f62-b546-02cc6e8a1d09",
				CustomerPhoneNumber = 222666111,
				CustomerFirstName = "Michal1",
				CustomerEmail = "test1@gmail.com",
				Date = DateTime.Now
			},
			new Appointment
			{
				Id = 3,
				ServiceId = 2,
				EmployeeId = "ae06c675-dbfb-4f62-b546-02cc6e8a1d09",
				CustomerPhoneNumber = 222666111,
				CustomerFirstName = "Michal2",
				CustomerEmail = "test2@gmail.com",
				Date = DateTime.Now
			});
	}
}
