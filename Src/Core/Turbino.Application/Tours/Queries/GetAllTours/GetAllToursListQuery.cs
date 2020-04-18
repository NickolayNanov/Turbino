using MediatR;

namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    public class GetAllToursListQuery : IRequest<GetAllToursListViewModel>
    {
        public int? PageIndex { get; set; }
    }
}
