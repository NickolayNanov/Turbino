using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    public class DestinationController : BaseController
    {
        [HttpGet]
        [Route("Destinations")]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Inquire(string destinationName)
        {
            return this.View();
        }
    }
}
