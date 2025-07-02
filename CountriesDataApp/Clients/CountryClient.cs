using System.Text.Json;
using CountriesDataApp.DTOs;

namespace CountriesDataApp.Clients
{
    public class CountryClient : ICountryClient
    {
        private readonly HttpClient _httpClient;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public CountryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryDto>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("/v3.1/all?fields=name,region,population,capital,flags,cca3", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                Console.WriteLine($"API call failed: {(int)response.StatusCode} {response.ReasonPhrase}, Details: {error}");
                return new List<CountryDto>();
            }

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            var countries = await JsonSerializer.DeserializeAsync<List<CountryDto>>(stream, _jsonOptions, cancellationToken);

            return countries ?? new List<CountryDto>();
        }

        public Task<List<CountryDto>> GetCountriesByLanguageAsync(string language, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<CountryDto>> GetCountriesByRegionAsync(string region, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<CountryDto>> GetCountriesBySubRegionAsync(string subRegion, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<CountryDto> GetCountryByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
