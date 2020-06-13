namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    using MediatR;

    public class GetAllDestinationsListQuery : IRequest<DestinationsListViewModel>   
    {
        public int? PageIndex { get; set; }
    }
}
