using Microsoft.AspNetCore.Identity;

namespace Do_an_NMCNPM.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Name {get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
