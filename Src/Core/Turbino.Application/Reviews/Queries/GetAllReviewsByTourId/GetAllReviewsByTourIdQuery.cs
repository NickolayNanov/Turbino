namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    using MediatR;

    public class GetAllReviewsByTourIdQuery : IRequest<GetAllReviewsByTourIdListViewModel>
    {
        public string TourId { get; set; }
    }
}
