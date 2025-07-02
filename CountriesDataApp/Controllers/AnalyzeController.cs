using Microsoft.AspNetCore.Mvc;
using CountriesDataApp.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountriesDataApp.Controllers
{
    [Route("analyze")]
    public class AnalyzeController : Controller
    {
        private readonly ICountryAnalysisService _analysisService;
        private readonly ILogger<AnalyzeController> _logger;

        public AnalyzeController(ICountryAnalysisService analysisService, ILogger<AnalyzeController> logger)
        {
            _analysisService = analysisService;
            _logger = logger;

            _logger.LogInformation("Started AnalyzeController");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Analyze endpoint hit");
            await _analysisService.AnalyzeCountriesAsync().ConfigureAwait(false);

            return Ok("Analysis done. Check logs.");
        }
    }
}
