using CountriesDataApp.Models;

namespace CountriesDataApp.Services.Analysis
{
    public class RegionCountAnalyzer : ICountryAnalyzer
    {
        public void Analyze(IEnumerable<Country> countries)
        {
            var regionCounts = countries
                .AsParallel()
                .GroupBy(c => c.Region ?? "Unknown")
                .Select(g => new { Region = g.Key, Count = g.Count() });

            Console.WriteLine("Countries by Region:");
            foreach (var region in regionCounts)
            {
                Console.WriteLine($" - {region.Region}: {region.Count} countries");
            }
        }
    }
}
