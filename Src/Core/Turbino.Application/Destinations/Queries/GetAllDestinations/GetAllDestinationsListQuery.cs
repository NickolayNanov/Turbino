using MediatR;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class GetAllDestinationsListQuery : IRequest<DestinationsListViewModel>   
    {
        public int? PageIndex { get; set; }
    }
}
