using MediatR;
using Turbino.Application.Destinations.Queries.GetAllDestinations;

namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    public class GetAllDestinationsWithFilterQuery : IRequest<GetAllDestinationsWithFilterListViewModel>
    {
        public string DestinationName { get; set; }

        public int? PageIndex { get; set; }
    }
}
