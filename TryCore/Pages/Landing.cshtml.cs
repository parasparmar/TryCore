using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TryCore.Persistence;

namespace TryCore.Pages
{
    public class LandingModel : PageModel
    {
        public ProductDbContext _db { get; set; }
        public LandingModel(ProductDbContext ctx) => _db = ctx;
        public void OnGet()
        {
        }
    }
}
