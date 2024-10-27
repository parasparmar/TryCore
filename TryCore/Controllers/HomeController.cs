using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TryCore.Models;
using TryCore.Persistence;

namespace TryCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDbContext _db;
        public HomeController(ILogger<HomeController> logger, ProductDbContext ctx)
        {
            _logger = logger;
            _db = ctx;
        }

        public IActionResult Index()
        {
            var p = _db.Products;
            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
