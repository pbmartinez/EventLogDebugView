using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("/Division")]
        public ActionResult<double> Division(int a, int b)
        {
            System.Diagnostics.Debug.WriteLine("Logging con debug");
            System.Diagnostics.Trace.WriteLine("Logging con trace");
            _logger.LogDebug("Logging Debug: Initiating division method");
            _logger.LogInformation("Logging Information: Executing division");
            if (a == 0 || b == 0)
                _logger.LogWarning("Logging Warning: Careful with division by 0");
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {
                _logger.LogError("Logging Error: Some error during Division: {Message}", ex.Message);
            }
            return BadRequest();
        }
    }
}