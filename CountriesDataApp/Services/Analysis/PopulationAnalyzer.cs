using CountriesDataApp.Models;
using System.Collections.Concurrent;

namespace CountriesDataApp.Services.Analysis
{
    public class PopulationAnalyzer : ICountryAnalyzer
    {
        private readonly int _threshold;

        public PopulationAnalyzer(int threshold = 100_000_000)
        {
            _threshold = threshold;
        }

        public void Analyze(IEnumerable<Country> countries)
        {
            var highPopCountries = new ConcurrentBag<Country>();

            Parallel.ForEach(countries, country =>
            {
                if (country.Population > _threshold)
                {
                    highPopCountries.Add(country);
                }
            });

            Console.WriteLine($"\nCountries with population > {_threshold:N0}:");
            foreach (var country in highPopCountries)
            {
                Console.WriteLine($" - {country.CommonName} ({country.Population:N0})");
            }
        }
    }
}