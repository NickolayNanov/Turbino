namespace Turbino.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Turbino.Application.Reservations.Queries.GetAllReservationsByUser;

    [Authorize]
    public class ReservationController : BaseController
    {
        [HttpGet]
        [Route("Reservations")]
        public async Task<IActionResult> Index()
        {
            GetAllReservationsByUserList reservations = await Mediator.Send(new GetAllReservationsByUserQuery() { Username = User.Identity.Name });
            return View(reservations);
        }
    }
}
