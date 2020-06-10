using MediatR;
using Turbino.Application.Tours.Queries.GetAllDestinations;

namespace Turbino.Application.Home.Queries.GetIndex
{
    public class GetIndexQuery : IRequest<IndexHolderViewModel>
    {
    }
}
