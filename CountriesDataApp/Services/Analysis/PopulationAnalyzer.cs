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
            var highPopCountries = countries
             .AsParallel()
                .Where(c => c.Population > _threshold)
              .ToList();

            _logger.LogInformation("=== Countries with population >= {Threshold:N0} ===", _threshold);


            foreach (var country in highPopCountries.OrderByDescending(c => c.Population))
            {
                _logger.LogInformation(" - {Country} ({Population:N0})", country.CommonName, country.Population);
            }

            _logger.LogInformation("Total high population countries: {Count}", highPopCountries.Count);
        }

    }
}