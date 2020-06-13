namespace Turbino.Application.Home.Queries.GetIndex
{
    using MediatR;

    using Turbino.Application.Tours.Queries.GetAllDestinations;

    public class GetIndexQuery : IRequest<IndexHolderViewModel>
    {
    }
}
