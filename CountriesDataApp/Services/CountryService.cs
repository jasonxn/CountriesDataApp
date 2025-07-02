using CountriesDataApp.Clients;
using CountriesDataApp.DTOs;
using CountriesDataApp.Mappings;
using CountriesDataApp.Models;
using CountriesDataApp.Repositories;
using CountriesDataApp.Services;
using System.Diagnostics.Metrics;

namespace CountriesDataApp.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryClient _client;
        private readonly ICountryRepository _repository;

        public CountryService(ICountryClient client, ICountryRepository repository)
        {
            _client = client;
            _repository = repository;
        }

        public async Task<List<Country>> RefreshCountriesAsync(CancellationToken cancellationToken = default)
        {
            // 1. Fetch DTOs from API
            var dtos = await _client.GetAllCountriesAsync(cancellationToken);

            // 2. Map to Entities
            var entities = dtos.ToEntityList();

            // 3. Persist to database (you may clear old data first if desired)
            await _repository.AddRangeAsync(entities, cancellationToken);

            // 4. Return saved data
            return entities.ToList();
        }

        public Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            return _repository.GetAllAsync(cancellationToken);
        }

        public Task AnalyzeCountriesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
