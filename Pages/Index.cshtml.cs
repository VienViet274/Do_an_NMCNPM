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
            Website_Destination website = new Website_Destination();
            website.Website_Link = "https://conferenceindex.org/conferences/information-technology";
            
            var List = _db.Destinations.ToList();
            _db.Destinations.Add(website);
            _db.SaveChanges();
        }
        
    }
}
