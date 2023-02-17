using System.Diagnostics;
using CarServiceASPProject.Models;
using CarServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceASPProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarServiceDbContext _db;

        public HomeController(CarServiceDbContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Cars.ToListAsync());
        }
        

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}