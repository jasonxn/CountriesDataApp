using CountriesDataApp.Models;
using CountriesDataApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CountriesDataApp.Services.Analysis
{
    public class PopulationAnalyzer : ICountryAnalyzer
    {
        private readonly int _threshold = 100_000_000;
        private readonly ILogger<PopulationAnalyzer> _logger;

        public PopulationAnalyzer(ILogger<PopulationAnalyzer> logger)
        {
            _logger = logger;
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

            Console.WriteLine($"Total countries fetched: {countries.Count()}");
            _logger.LogInformation("=== Countries with population >= {Threshold:N0} ===", _threshold);

            Console.WriteLine($"\nCountries with population > {_threshold:N0}:");

            foreach (var country in highPopCountries.OrderByDescending(c => c.Population))
            {
                Console.WriteLine($" - {country.CommonName} ({country.Population:N0})");
                _logger.LogInformation(" - {Country} ({Population:N0})", country.CommonName, country.Population);
            }

            _logger.LogInformation("Total high population countries: {Count}", highPopCountries.Count);
        }

    }
}