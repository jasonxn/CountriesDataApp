using CountriesDataApp.DTOs;
using CountriesDataApp.Models;
using System.Diagnostics.Metrics;
using System.Linq;
namespace CountriesDataApp.Mappings
{
    public static class CountryMappingExtensions
    {
        public static Country ToEntity(this CountryDto dto)
        {
            return new Country
            {
                Code = dto.Cca3,
                CommonName = dto.Name.Common,
                OfficialName = dto.Name.Official,
                Region = dto.Region,
                Capital = dto.Capital?.FirstOrDefault() ?? "N/A",
                Population = dto.Population,
                FlagPngUrl = dto.Flags?.Png ?? string.Empty
            };
        }
        public static IEnumerable<Country> ToEntityList(this IEnumerable<CountryDto> dtos)
        {
            return dtos.Select(dto => dto.ToEntity());
        }
    }
}
