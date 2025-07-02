using Microsoft.EntityFrameworkCore;
using CountriesDataApp.Models;

namespace CountriesDataApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; } = null!;
       
    }
}
