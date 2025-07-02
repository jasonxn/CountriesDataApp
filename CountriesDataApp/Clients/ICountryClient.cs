using CountriesDataApp.DTOs;
using System.Threading;

namespace CountriesDataApp.Clients
{
    public interface ICountryClient
    {
        Task<List<CountryDto>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
        Task<CountryDto> GetCountryByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<List<CountryDto>> GetCountriesByRegionAsync(string region, CancellationToken cancellationToken = default);
        Task<List<CountryDto>> GetCountriesBySubRegionAsync(string subRegion, CancellationToken cancellationToken = default);
        Task<List<CountryDto>> GetCountriesByLanguageAsync(string language, CancellationToken cancellationToken = default);
    }
}
