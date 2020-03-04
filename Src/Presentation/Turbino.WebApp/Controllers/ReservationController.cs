using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    public class ReservationController : BaseController
    {
        [HttpGet]
        [Route("Reservations")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
