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
        
        public string Chuoi { get; set; } = string.Empty;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; } = 1;
        public int TotalPage { get; set; } = 0;
        public IEnumerable<Conference> itemOnPage { get; set; } = new List<Conference>();
        public HeaderModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Conferences = _db.Conferences.ToList();
            if(Conferences == null|| Conferences.Count == 0)
            {
                Chuoi = "No data found";
            }
            PageCount = int.TryParse(Request.Query["PageCount"], out int paarseNumber) ? paarseNumber : 1;
            TotalPage = (int)Math.Ceiling((double)Conferences.Count / PageSize);
            itemOnPage = Conferences.Skip((PageCount - 1) * PageSize).Take(PageSize);
        }   
        public void OnPost(string keyword)
        {


            var list = _db.Conferences.ToList().FindAll(x=>x.Name.Contains(keyword));
            if(list.Count == 0|| list == null)
            {
                Chuoi = $"No data contains  '{keyword}' ";
            }
            else
            {
                Conferences = list;
                PageCount = int.TryParse(Request.Query["PageCount"], out int paarseNumber) ? paarseNumber : 1;
                TotalPage = (int)Math.Ceiling((double)Conferences.Count / PageSize);
                itemOnPage = Conferences.Skip((PageCount - 1) * PageSize).Take(PageSize);
            }
            
        }
    }
}
