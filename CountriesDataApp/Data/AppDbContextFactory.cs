using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
// ASk Ali !!!

namespace CountriesDataApp.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=CountriesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }

}
