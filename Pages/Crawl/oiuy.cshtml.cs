using Do_an_NMCNPM.Data;
using Do_an_NMCNPM.Handle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Do_an_NMCNPM.Pages.Crawl
{
    public class oiuyModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public oiuyModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            callDriver callDriver = new callDriver();
            var ans = callDriver.crawlConference();
            int k = 0;
            _db.Conferences.AddRange(ans);
            _db.SaveChanges();
        }
    }
}
