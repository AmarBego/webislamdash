using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webislamdash.Models;

namespace webislamdash.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<webislamdash.Models.Prayer> Prayer { get; set; } = default!;
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
