using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TryCore.Models;
using TryCore.Persistence;

namespace TryCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private ProductDbContext _db;
        public AdminController(ILogger<AdminController> logger, ProductDbContext ctx)
        {
            _logger = logger;
            _db = ctx;
        }
        public IActionResult Index()
        {
            var p = _db.Products;
            return View(p);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Product p = _db.Find<Product>(id);
            if (p != null)
            {
                return View("Edit", p);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Save(Product p)
        {
            _db.Update(p);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            Product p = _db.Find<Product>(id);
            if (p != null)
            {
                _db.Remove(p);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
