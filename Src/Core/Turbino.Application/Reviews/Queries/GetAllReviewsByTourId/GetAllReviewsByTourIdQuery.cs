using MediatR;

namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    public class GetAllReviewsByTourIdQuery : IRequest<GetAllReviewsByTourIdListViewModel>
    {
        public string TourId { get; set; }
    }
}
