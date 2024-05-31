using Do_an_NMCNPM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.WebRequestMethods;

namespace Do_an_NMCNPM.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
            
        }
        public DbSet<Website_Destination> Destinations { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Website_Destination>().HasData
            (
                new Website_Destination { ID = 1, Website_Link = "https://www.conferenceineurope.org/information_technology.php" }
                );
        }
    }
}
