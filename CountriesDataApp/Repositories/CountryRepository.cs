using CountriesDataApp.Data;
using CountriesDataApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;

namespace CountriesDataApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(IEnumerable<Country> countries, CancellationToken cancellationToken = default)
        {
            // Remove existing data 
            _context.Countries.RemoveRange(_context.Countries);
            await _context.Countries.AddRangeAsync(countries, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Countries.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

    }
}
