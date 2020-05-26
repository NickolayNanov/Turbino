using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Turbino.Application.Reservations.Commands.CreateReservation;
using Turbino.Application.Reservations.Queries.GetAllReservationsByUser;

namespace Turbino.WebApp.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Reserve(string reserverName, DateTime arrivalDate, DateTime dateOfLeaving, string tourId)
        {
            await Mediator.Send(new CreateReservationCommand() { Name = reserverName, UserName = User.Identity.Name, TourId = tourId, DepartureDate = arrivalDate, DateOfLeaving = dateOfLeaving});
            return this.RedirectToAction("Index", "Reservation");
        }
    }
}
