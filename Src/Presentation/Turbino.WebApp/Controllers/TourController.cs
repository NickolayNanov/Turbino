using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Turbino.Application.Reservations.Commands.CreateReservation;
using Turbino.Application.Reviews.Commands;
using Turbino.Application.Tours.Queries.GetAllDestinations;
using Turbino.Application.Tours.Queries.GetAllToursFiltered;
using Turbino.Application.Tours.Queries.SelectById;

namespace Turbino.WebApp.Controllers
{
    public class TourController : BaseController
    {
        [HttpGet]
        [Route("Tours")]
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            GetAllToursListViewModel result = await Mediator.Send(new GetAllToursListQuery() { PageIndex = pageNumber });
            return View(result);
        }

        [Authorize]
        [HttpGet]
        [Route("InquireTour")]
        public async Task<IActionResult> Inquire(string tourId)
        {
            TourViewModel model = await Mediator.Send(new GetTourByIdQuery(tourId));
            return View(model);
        }

        [HttpGet]
        [Route("FilteredTours")]
        public async Task<IActionResult> Filter(GetAllToursListViewModel query, int? pageNumber = 1)
        {
            GetAllToursWithFilterListViewModel tours = await Mediator.Send(new GetAllToursWithFilterQuery() { TourName = query.TourName, TourType = query.TourType, DestinationName = query.DestinationName, SortOrder = query.SortOrder, Month = query.Month, PriceStr = query.PriceStr, PageIndex = pageNumber });
            if(tours.Errors.Length != 0)
            {
                GetAllToursListViewModel allTours = await Mediator.Send(new GetAllToursListQuery() { PageIndex = pageNumber });
                ViewData["Errors"] = tours.Errors;
                return View(allTours);
            }
            
            return View(tours);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview(string name, string email, string rating, string content, string tourId)
        {
            await Mediator.Send(new CreateReviewCommand() { Name = name, Email = email, Rating = rating, Content = content, TourId = tourId, AuthorName = User.Identity.Name });
            var model = await Mediator.Send(new GetTourByIdQuery(tourId));
            return View("Inquire", model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(CreateReservationCommand command)
        {
            command.UserName = User.Identity.Name;
            string[] errors = await Mediator.Send(command);
            if (errors != null)
            {
                ViewData["Error"] = errors;
                TourViewModel model = await Mediator.Send(new GetTourByIdQuery(command.TourId));
                return View("Inquire", model);
            }

            return this.RedirectToAction("Index", "Reservation");
        }
    }
}
