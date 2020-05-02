using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    [Authorize]
    public class ReservationController : BaseController
    {
        [HttpGet]
        [Route("Reservations")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
