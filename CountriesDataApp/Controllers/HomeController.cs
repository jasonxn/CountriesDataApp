using System.Diagnostics;
using CountriesDataApp.Models;
using Microsoft.AspNetCore.Mvc;
using CountriesDataApp.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountriesDataApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;

        public HomeController(ILogger<HomeController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/refresh")]
        public async Task<IActionResult> Refresh()
        {
            var countries = await _countryService.RefreshCountriesAsync().ConfigureAwait(false);

            return Content($"Loaded {countries.Count} countries into the database.");
         
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
             => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    
    }
}
