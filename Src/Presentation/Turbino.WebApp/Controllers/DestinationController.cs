using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered;
using Turbino.Application.Destinations.Queries.GetDestinationById;

namespace Turbino.WebApp.Controllers
{
    public class DestinationController : BaseController
    {
        [HttpGet]
        [Route("Destinations")]
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            DestinationsListViewModel result = await Mediator.Send(new GetAllDestinationsListQuery() { PageIndex = pageNumber});
            return this.View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Inquire(string destinationId)
        {
            DestinationViewModel result = await Mediator.Send(new GetDestinationByIdQuery(destinationId));
            return this.View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string searchQuery, string priceRange)
        {
            DestinationsListViewModel result = await Mediator.Send(new GetAllDestinationsWithFilterQuery() { DestinationName = searchQuery });
            return this.View("Index", 1);
        }
    }
}