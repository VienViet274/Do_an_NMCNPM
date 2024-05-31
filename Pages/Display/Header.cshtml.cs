using Do_an_NMCNPM.Data;
using Do_an_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Do_an_NMCNPM.Pages.Display
{
    public class HeaderModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Conference> Conferences { get; set; }
        public HeaderModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Conferences = _db.Conferences.ToList();
        }
    }
}
