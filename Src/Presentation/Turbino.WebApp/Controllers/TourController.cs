using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            return this.View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Inquire(string tourId)
        {
            TourViewModel model = await Mediator.Send(new GetTourByIdQuery(tourId));
            return this.View(model);
        }

        [HttpGet]
        [Route("FilteredTours")]
        public async Task<IActionResult> Filter(GetAllToursListViewModel query, int? pageNumber = 1)
        {
            GetAllToursWithFilterListViewModel tours = await Mediator.Send(new GetAllToursWithFilterQuery() { TourName = query.TourName, TourType = query.TourType, DestinationName = query.DestinationName, SortOrder = query.SortOrder, Month = query.Month, PriceStr = query.PriceStr, PageIndex = pageNumber });
            return this.View(tours);
        }
    }
}
