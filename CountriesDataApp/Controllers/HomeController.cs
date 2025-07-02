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
            // This will fetch from the API, map to entities, and save to the DB
            var countries = await _countryService.RefreshCountriesAsync().ConfigureAwait(false);

            // For simplicity, return the saved list as JSON:
            //return Json(countries);
            return Content($"Loaded {countries.Count} countries into the database.");

            // Alternatively, you could redirect back to Index, or pass to a View:
            // return RedirectToAction(nameof(Index));
            // or
            // return View("CountryList", countries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
             => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


        [Route("analyze")]
        public class AnalyzeController : Controller
        {
            private readonly ICountryAnalysisService _analysisService;

            public AnalyzeController(ICountryAnalysisService analysisService)
            {
                _analysisService = analysisService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                await _analysisService.AnalyzeCountriesAsync().ConfigureAwait(false);   
                return Ok("Analysis done. Check server console.");
            }
        }



    }
}
