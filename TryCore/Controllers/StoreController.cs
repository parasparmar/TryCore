using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryCore.Persistence;

namespace TryCore.Controllers
{
    
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private ProductDbContext _db;
        public StoreController(ILogger<StoreController> logger, ProductDbContext ctx)
        {
            _logger = logger;
            _db = ctx;
        }
        public IActionResult Index()
        {
            var p = _db.Products;
            return View(p);
        }
    }
}
