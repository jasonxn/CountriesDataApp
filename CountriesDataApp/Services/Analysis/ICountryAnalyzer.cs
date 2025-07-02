using CountriesDataApp.Models;
using CountriesDataApp.Services;

namespace CountriesDataApp.Services.Analysis
{
    public interface ICountryAnalyzer
    {
        void Analyze(IEnumerable<Country> countries);
    }
}
