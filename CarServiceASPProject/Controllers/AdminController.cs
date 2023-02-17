using System.Diagnostics;
using CarServiceASPProject.Models;
using CarServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceASPProject.Controllers;

public class AdminController : Controller
{

    private readonly CarServiceDbContext _db;

    
    public AdminController(CarServiceDbContext context)
    {
        _db = context;
    }

    public IActionResult AdminPanel()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}