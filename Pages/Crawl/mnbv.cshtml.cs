using Do_an_NMCNPM.Data;
using Do_an_NMCNPM.Handle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Do_an_NMCNPM.Pages.Crawl
{
    public class mnbvModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public mnbvModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            callDriver2 callDriver = new callDriver2();
            var ans = callDriver.crawlConference();
            _db.Conferences.AddRange(ans);
            _db.SaveChanges();
        }
    }
}
