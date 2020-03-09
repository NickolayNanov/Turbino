using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Application.Destinations.Queries.GetDestinationById;

namespace Turbino.WebApp.Controllers
{
    public class DestinationController : BaseController
    {
        [HttpGet]
        [Route("Destinations")]
        public async Task<IActionResult> Index()
        {
            DestinationsListViewModel result = await Mediator.Send(new GetAllDestinationsListQuery());
            return this.View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Inquire(string destinationId)
        {
            DestinationViewModel result = await Mediator.Send(new GetDestinationByIdQuery(destinationId));
            return this.View(result);
        }

        public IActionResult Filter(int start, int end, string range)
        {
            return this.View();
        }
    }
}
