namespace Turbino.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Turbino.Application.Reservations.Queries.GetAllReservationsByUser;

    [Authorize]
    public class ReservationController : BaseController
    {
        private const string ReservationsIndexRoute = "Reservations";

        [HttpGet]
        [Route(ReservationsIndexRoute)]
        public async Task<IActionResult> Index()
        {
            GetAllReservationsByUserList reservations = await Mediator.Send(new GetAllReservationsByUserQuery() { Username = User.Identity.Name });
            return View(reservations);
        }
    }
}
