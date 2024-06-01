using Do_an_NMCNPM.Data;
using Do_an_NMCNPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Do_an_NMCNPM.Pages.Display
{
    public class ComponentModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Conference Conference { get; set; }
        public string Notice { get; set; }
        public ComponentModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            var list = _db.Conferences.ToList();
            var item = list.Where(x => x.Id == Id).FirstOrDefault();
            if (item == null)
            {
                Notice = "No conference found";
            }
            else
            {
                Conference = item;
                

            }
        }
    }
}
