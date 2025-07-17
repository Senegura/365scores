using Microsoft.AspNetCore.Mvc;

namespace Scores365.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ScoreController> _logger;

        public ScoreController(ILogger<ScoreController> logger)
        {
            _logger = logger;
        }
    }
}
