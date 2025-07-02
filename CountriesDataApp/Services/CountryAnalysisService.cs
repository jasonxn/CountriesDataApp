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

        public CountryAnalysisService(ICountryService countryService, IEnumerable<ICountryAnalyzer> analyzers)
        {
            _countryService = countryService;
            _analyzers = analyzers;
        }


        public async Task AnalyzeCountriesAsync(CancellationToken cancellationToken = default)
        {
            var countries = await _countryService.GetAllCountriesAsync(cancellationToken);

            Console.WriteLine("Parallel Analysis Started...\n");

            foreach (var analyzer in _analyzers)
            {
                analyzer.Analyze(countries);
            }

        }
    }
}
