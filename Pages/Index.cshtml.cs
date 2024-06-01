using Do_an_NMCNPM.Data;
using Do_an_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Do_an_NMCNPM.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            
        }

    }
}
