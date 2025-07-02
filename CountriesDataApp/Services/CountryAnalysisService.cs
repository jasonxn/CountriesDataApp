using CountriesDataApp.Data;
using CountriesDataApp.Models;
using CountriesDataApp.Services.Analysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;


namespace CountriesDataApp.Services
{
    public class CountryAnalysisService : ICountryAnalysisService
    {
        private readonly ICountryService _countryService;
        private readonly IEnumerable<ICountryAnalyzer> _analyzers;
        private readonly ILogger<CountryAnalysisService> _logger;

        public CountryAnalysisService(ICountryService countryService, IEnumerable<ICountryAnalyzer> analyzers, ILogger<CountryAnalysisService> logger)
        {
            _countryService = countryService;
            _analyzers = analyzers;
            _logger = logger;
            Console.WriteLine("CountryAnalysisService instantiated writeline"); 
            _logger.LogInformation("CountryAnalysisService instantiated loginformation");

        }


        public async Task AnalyzeCountriesAsync(CancellationToken cancellationToken = default)
        {
            var countries = await _countryService.GetAllCountriesAsync(cancellationToken).ConfigureAwait(false);

            Console.WriteLine("Parallel Analysis Started...\n");
            _logger.LogInformation("Parallel Analysis Started...LOgeinnnn\n");

            try
            {
                foreach (var analyzer in _analyzers)
                {
                    _logger.LogInformation($"Running analyzer: {analyzer.GetType().Name}");
                    analyzer.Analyze(countries);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[ERROR] Analyzer execution failed: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }


        }
    }
}
