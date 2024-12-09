using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using HairSaloon.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace HairSaloonWeb;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

		builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
		// Dodanie funkcjonalnoœci .NET idenfity, tutaj deklarujemy role i model u¿ytkownika

		builder.Services.ConfigureApplicationCookie(options =>
		{
			options.LoginPath = $"/Identity/Account/Login";
			options.LogoutPath = $"/Identity/Account/Logout";
			options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
		}); /* Dodaje konfiguracje aby program przekierowa³ do nastêpuj¹cych œcie¿ek.
		Np nieautoryzowany dostêp do panelu admina powoduje przekierowanie do loogowania
		Powy¿sze opcje w³aœnie do umo¿liwiaj¹. Musi byæ pod AddIdentity */


		builder.Services.AddRazorPages(); // Add AddRazorPages i MapRazor Pages wziê³o siê z tego ¿e .NET identity obs³uguje tylko razora
										  // Dodajemy te konfiguracje ¿eby routing zadzia³a³

		builder.Services.AddScoped<IEmailSender, EmailSender>();
		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

		var app = builder.Build();

		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthentication(); // Zawsze autentykacja jest przed autoryzacj¹
		app.UseAuthorization();

		app.MapRazorPages();
		app.MapControllerRoute(
			name: "default",
			pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}