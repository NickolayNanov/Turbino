using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Tours.Queries.GetAllDestinations;

namespace Turbino.WebApp.Controllers
{
    public class TourController : BaseController
    {
        [HttpGet]
        [Route("Tours")]
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            GetAllToursListViewModel result = await Mediator.Send(new GetAllToursListQuery() { PageIndex = pageNumber });
            return this.View(result);
        }

        [HttpGet]
        public IActionResult Inquire(string tourId)
        {
            return this.View();
        }
    }
}
