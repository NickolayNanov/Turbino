namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    using MediatR;

    public class GetAllDestinationsWithFilterQuery : IRequest<GetAllDestinationsWithFilterListViewModel>
    {
        public string DestinationName { get; set; }

        public int? PageIndex { get; set; }
    }
}
