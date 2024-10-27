using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TryCore.Persistence;

namespace TryCore.Pages
{
    public class StoreModel : PageModel
    {
        public ProductDbContext _db { get; set; }
        public StoreModel(ProductDbContext ctx)
        {
            _db = ctx;
        }
        public void OnGet()
        {
        }
    }
}