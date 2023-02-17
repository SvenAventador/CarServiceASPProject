using System.Diagnostics;
using CarServiceASPProject.Models;
using CarServiceLibrary.Models;
using CarServiceLibrary.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceASPProject.Controllers;

public class AccountController : Controller
{
    private readonly CarServiceDbContext _db;

    public AccountController(CarServiceDbContext context)
    {
        _db = context;
    }

    public IActionResult Test()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAccount(Users user)
    {
        if (!ModelState.IsValid) return Content("Не валидно!");
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return RedirectToAction("Login");

    }

    [HttpPost]
    public async Task<IActionResult> Login(string phone, string password)
    {
        if (!CarServiceProject.Validator.Validator.ValidatePhone(phone)) return Content("Не валидный телефон!");

        if (!CarServiceProject.Validator.Validator.ValidatePassword(password)) return Content("Не валидный пароль!");

        var findUser =
            await _db.Users.FirstOrDefaultAsync(x => x.TelephoneNumber == phone && x.PasswordUser == password);

        if (findUser != null) return Redirect("/MainActions/Diagnostic");
        
        return NotFound();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}