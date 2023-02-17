using System.Diagnostics;
using CarServiceASPProject.Models;
using CarServiceLibrary.Models;
using CarServiceLibrary.Models.Entities;
using CarServiceLibrary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8602

namespace CarServiceASPProject.Controllers;

public class MainActionsController : Controller
{
    private readonly CarServiceDbContext _db;

    public MainActionsController(CarServiceDbContext context)
    {
        _db = context;
    }

    #region Вывод данных услуг.

    public IActionResult Maintenance()
    {
        var services = _db.Services.
                                    Where(s => s.TypeId == 2)
                                    .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
            select new SelectListItem()
            {
                Text = car.CarName,
                Value = car.Id.ToString()
            }).ToList();
        
        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }


    public IActionResult Detailing()
    {
        var services = _db.Services.
            Where(s => s.TypeId == 3)
            .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
            select new SelectListItem
            {
                Text = car.CarName,
                Value = car.Id.ToString()
            }).ToList();
        
        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }
    
    public IActionResult Diagnostic()
    {
        var services = _db.Services.
            Where(s => s.TypeId == 4)
            .ToList();
        var vm = new ServicesViewModel
        {
            Services = services
        };

        var carList = (from car in _db.Cars
            select new SelectListItem()
            {
                Text = car.CarName,
                Value = car.Id.ToString()
            }).ToList();
        
        carList.Insert(0, new SelectListItem()
        {
            Text = "Пожалуйста, выберите марку автомобиля!",
            Value = string.Empty
        });

        var cars = _db.Cars.ToList();

        var cM = new CarsViewModel
        {
            ListofCar = carList
        };

        var modelTuple = (cM, vm);

        ViewBag.ListofCars = carList;

        return View(modelTuple);
    }

    public IActionResult GetService(int id)
    {
        var service = _db.Services.Find(id);
        return Json(service);
    }

    #endregion
    
    #region Вывод представлений на экран.

    public IActionResult Repair() => View();

    public IActionResult Contacts() => View();

    public IActionResult OnMarks() => View();

    public IActionResult AboutService() => View();

    #endregion

    #region Создание заявок на услуги.

    [HttpPost]
    public async Task<IActionResult> CreateOrder(string userName, string carName, string carModel, string phone, string serviceName)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.TelephoneNumber == phone);
        var userId = user?.Id ?? 1;

        var service = await _db.Services.FirstOrDefaultAsync(x => x.ServiceName == serviceName);
        var serviceId = service.Id;
        var order = new Orders(userId, serviceId, userName, 1, int.Parse(carName), carModel);

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return RedirectToAction("Diagnostic");
    }

    #endregion

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}