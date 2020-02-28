using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    public class TourController : BaseController
    {
        [HttpGet]
        [Route("Tours")]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Inquire(string tourId)
        {
            return this.View();
        }
    }
}
