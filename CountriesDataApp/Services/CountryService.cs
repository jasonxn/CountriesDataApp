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
            var dtos = await _client.GetAllCountriesAsync(cancellationToken);

            var entities = dtos.ToEntityList();

            await _repository.AddRangeAsync(entities, cancellationToken);

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
