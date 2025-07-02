using System.Threading;
using System.Threading.Tasks;

namespace CountriesDataApp.Services
{
    public interface ICountryAnalysisService
    {
      public Task AnalyzeCountriesAsync(CancellationToken cancellationToken = default);

    }
}
