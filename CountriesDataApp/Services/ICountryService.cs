using CountriesDataApp.DTOs;
using CountriesDataApp.Models;
using System.Diagnostics.Metrics;
using System.Threading;

namespace CountriesDataApp.Services
{
    public interface ICountryService
    {
        /// <summary>
        /// Retrieves from API, maps, and saves to the database.
        /// Returns the list of saved entities.
        /// </summary>
        Task<List<Country>> RefreshCountriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns all countries currently in the database.
        /// </summary>
        Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs analysis on saved country data using parallel operations.
        /// </summary>
        Task AnalyzeCountriesAsync(CancellationToken cancellationToken = default);

    }
}

