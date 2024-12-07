using HairSaloon.DataAccess.Data;
using HairSaloon.Models;
using HairSaloon.Models.ViewModels;
using HairSaloon.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairSaloonWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class UserController : Controller
{
    // W tym kontrolerze nie będziemy używać _unit of work
    //private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEnumerable<IdentityRole> roles;
    private readonly IEnumerable<IdentityUserRole<string>> userRoles;


    public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
    {

        _db = db;
        _userManager = userManager;
        roles = _db.Roles.ToList();
        userRoles = _db.UserRoles.ToList();
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
        => View(new CreateApplicationUserVM());

    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> Create(CreateApplicationUserVM AppUserVM)
    {
        if (!ModelState.IsValid)
            return View(AppUserVM);

        var user = CreateUser();

        if (!String.IsNullOrEmpty(AppUserVM.Email))
        {
            user.Email = AppUserVM.Email;
        }
        else
        {
            user.Email = $"{AppUserVM.FirstName[0]}{AppUserVM.LastName}@example.com";
        }

        user.UserName = user.Email.ToLower();
        user.FirstName = AppUserVM.FirstName;
        user.LastName = AppUserVM.LastName;

        var result = await _userManager.CreateAsync(user, AppUserVM.Password);

        if (result.Succeeded)
        {
            if (!String.IsNullOrEmpty(AppUserVM.Role))
            {
                await _userManager.AddToRoleAsync(user, AppUserVM.Role);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, SD.Role_Employee);
            }
        }

        return RedirectToAction("Index");
    }

    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    [HttpGet]
    public IActionResult Update(string? id)
    {

        if (id == null || id == "0")
            RedirectToAction("Create");

        ApplicationUser obj = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        ApplicationUserVM AppUserVM = new ApplicationUserVM(obj);
        AppUserVM.Role = GetDbUserRoleById(obj.Id);
        return View(AppUserVM);
    }

    [HttpPost, ActionName("Update")]
    public IActionResult Update(ApplicationUserVM userVM)
    {
        if (!ModelState.IsValid)
            return View(userVM);

        string oldRole = GetDbUserRoleById(userVM.Id);

        ApplicationUser AppUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userVM.Id);
        if (AppUser == null)
            return NotFound();

        // Modyfikacja roli
        if (oldRole != userVM.Role)
        {
            _userManager.RemoveFromRoleAsync(AppUser, oldRole).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(AppUser, userVM.Role).GetAwaiter().GetResult();
        }

        // Modyfikacja pozostalych pol
        AppUser.FirstName = userVM.FirstName;
        AppUser.LastName = userVM.LastName;
        _db.ApplicationUsers.Update(AppUser);
        _db.SaveChanges();
        TempData["success"] = "Category edited successfully";
        return RedirectToAction("Index");
    }

    private string GetDbUserRoleById(string id)
    {
        var roleId = userRoles.FirstOrDefault(u => u.UserId == id).RoleId;
        return roles.FirstOrDefault(u => u.Id == roleId).Name;
    }


    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<ApplicationUser> objUserList = _db.ApplicationUsers.ToList();

        foreach (var user in objUserList)
        {
            user.Role = GetDbUserRoleById(user.Id);
        };

        return Json(new { data = objUserList });
    }

    [HttpPost]
    public IActionResult LockUnlock([FromBody] string id)
    {
        var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
        if (objFromDb == null)
        {
            return Json(new { success = false, message = "Error while locking/unlocking" });
        }

        if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
        {
            // Odblokowanie użytkownika - jeśli jest zablokowany
            objFromDb.LockoutEnd = DateTime.Now;
        }
        else
        {
            // Odblokowanie użytkownika - jeśli jest zablokowany
            objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
        }

        _db.SaveChanges();
        return Json(new { success = true, message = "Locking/unlocking successfull" });
    }

    [HttpDelete, ActionName("Delete")]
    public async Task<IActionResult> Delete([FromBody] string id)
    {
        //First Fetch the User you want to Delete
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Json(new { success = false, message = "Nie znaleziono użytkownika" });
        }
        else
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Json(new { success = true, message = "Użytkownik został pomyślnie usunięty" });
            else
                return Json(new { success = false, message = "Wystąpił problem usuwania" });
        }
    }

    #endregion

}
