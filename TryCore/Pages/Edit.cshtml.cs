using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TryCore.Models;
using TryCore.Persistence;

namespace TryCore.Pages
{
    public class EditModel : PageModel
    {
        public ProductDbContext _db { get; set; }
        public EditModel(ProductDbContext ctx) => _db = ctx;
        public Product Product { get; set; }
        public void OnGet(long id)
        {
            Product = _db.Find<Product>(id) ?? new Product();
        }
        public IActionResult OnPost([Bind(Prefix = "Product")] Product p)
        {
            _db.Update(p);
            _db.SaveChanges();
            return RedirectToPage("Admin");
        }
    }
}
