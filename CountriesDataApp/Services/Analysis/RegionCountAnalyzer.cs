using CountriesDataApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CountriesDataApp.Services.Analysis
{
    public class RegionCountAnalyzer : ICountryAnalyzer
    {
        private readonly ILogger<RegionCountAnalyzer> _logger;

        public RegionCountAnalyzer(ILogger<RegionCountAnalyzer> logger)
        {
            _logger = logger;
        }

        public void Analyze(IEnumerable<Country> countries)
        {
            var regionCounts = countries
                .AsParallel()
                .GroupBy(c => c.Region ?? "Unknown")
                .Select(g => new
                { Region = g.Key, Count = g.Count() })
                .ToList();

            _logger.LogInformation("Country counts by Region");

            foreach (var region in regionCounts)
            {
                _logger.LogInformation(" - {Region}: {Count} countries", region.Region, region.Count);

            }
        }
    }
}
