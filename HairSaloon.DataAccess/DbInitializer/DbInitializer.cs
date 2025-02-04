using HairSaloon.DataAccess.Data;
using HairSaloon.Models;
using HairSaloon.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairSaloon.DataAccess.DbInitializer;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _db;

    public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
    }

    public void Initialize()
    {
        // Tworzenie migracji jeśli nie zostały jeszcze zaimplementowane
        try
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
                _db.Database.Migrate();
        }
        catch (Exception ex) { }

        // Create roles if not created

        if (!_roleManager.RoleExistsAsync(SD.Role_Employee).GetAwaiter().GetResult())
        // Get awaiter get result zastępuje await
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();

            // Jeśli nie ma roli to dodajemy admina
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@labella.com",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@labella.com",
                EmailConfirmed = true
            }, "Admin123!@#").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@labella.com");
            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
        }

        return;

    }
}
