using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TryCore.Models;
using TryCore.Persistence;

namespace TryCore.Pages
{
    public class AdminModel : PageModel
    {
        public ProductDbContext _db { get; set; }
        public AdminModel(ProductDbContext ctx) => _db = ctx;
        public IActionResult OnPost(long id)
        {
            Product p = _db.Find<Product>(id);
            if (p != null)
            {
                _db.Remove(p);
                _db.SaveChanges();
            }
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
