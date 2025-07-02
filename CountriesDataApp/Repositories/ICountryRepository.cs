
using CountriesDataApp.Models;
using CountriesDataApp.Services;

using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;

namespace CountriesDataApp.Repositories
{
    public interface ICountryRepository
    {
        /// <summary>
        /// Inserts or updates the given countries in the database.
        /// </summary>
        Task AddRangeAsync(IEnumerable<Country> countries, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all countries from the database.
        /// </summary>
        Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
