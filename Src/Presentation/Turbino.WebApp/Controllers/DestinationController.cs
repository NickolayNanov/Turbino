namespace Turbino.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Turbino.Application.Destinations.Queries.GetAllDestinations;
    using Turbino.Application.Destinations.Queries.GetDestinationById;
    using Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered;


    public class DestinationController : BaseController
    {
        [HttpGet]
        [Route("Destinations")]
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            DestinationsListViewModel result = await Mediator.Send(new GetAllDestinationsListQuery() { PageIndex = pageNumber});
            return View(result);
        }

        [Authorize]
        [HttpGet]
        [Route("InquireDestination")]
        public async Task<IActionResult> Inquire(string destinationId)
        {
            DestinationViewModel result = await Mediator.Send(new GetDestinationByIdQuery(destinationId));
            return View(result);
        }

        [HttpGet]
        [Route("FilteredDestinations")]
        public async Task<IActionResult> Filter(string searchQuery, int? pageNumber = 1)
        {
            DestinationsListViewModel result = await Mediator.Send(new GetAllDestinationsWithFilterQuery() { DestinationName = searchQuery, PageIndex = pageNumber });

            if(result.Errors.Length != 0)
            {
                ViewData["Errors"] = result.Errors;
            }

            return View(result);
        }
    }
}