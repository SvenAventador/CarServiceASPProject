using System.Diagnostics;
using CarServiceLibrary.Models;
using CarServiceLibrary.Models.Entities;
using CarServiceLibrary.ViewModels;
using CarServiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceProject.Controllers;

public class MainActionsController : Controller
{
    private readonly CarServiceDbContext _db;

    public MainActionsController(CarServiceDbContext context)
    {
        _db = context;
    }


    #region MyRegion

    public IActionResult Diagnostic()
    {
        var services = _db.Services.Where(s => s.TypeId == 4).ToList();
        var vm = new ServicesViewModel();
        vm.Services = services;
        return View(vm);
    }

    public async Task<IActionResult> Maintenance()
    {
        var services = _db.Services.Where(s => s.TypeId == 2).ToList();
        var vm = new ServicesViewModel();
        vm.Services = services;
        return View(vm);
    }

    public IActionResult GetService(int id)
    {
        var service = _db.Services.Find(id);
        return Json(service);
    }

    public IActionResult Repair()
    {
        return View();
    }

    public IActionResult Detailing()
    {
		var services = _db.Services.Where(s => s.TypeId == 3).ToList();
		ServicesViewModel vm = new ServicesViewModel();
		vm.Services = services;
		return View(vm);
	}

    public IActionResult Contacts()
    {
        return View();
    }

    public IActionResult OnMarks()
    {
        return View();
    }

    public IActionResult AboutService()
    {
        return View();
    }

    #endregion

    [HttpPost]
    public async Task<IActionResult> CreateOrder(string phone, string userName, string userCar, string carModel, int id)
    {
        if (string.IsNullOrEmpty(userName)) return Content("Пожалуйста, введите Ваше имя!");
        if (string.IsNullOrEmpty(carModel)) return Content("Пожалуйста, введите марку Вашей машины!");

        var user = await _db.Users.FirstOrDefaultAsync(x => x.TelephoneNumber == phone);
        var car = await _db.Cars.FirstOrDefaultAsync(x => x.CarName == userCar);

        var random = new Random();

        var carId = car?.Id ?? random.Next(1, 9);
        var userId = user?.Id ?? 1;

        var order = new Orders(userId, id, userName, 1, carId, carModel);

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return Content("WOW");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}