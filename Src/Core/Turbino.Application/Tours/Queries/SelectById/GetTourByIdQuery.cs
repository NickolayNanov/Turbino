namespace Turbino.Application.Tours.Queries.SelectById
{
    using MediatR;

    public class GetTourByIdQuery : IRequest<TourViewModel>
    {
        public GetTourByIdQuery()
        {

        }

        public GetTourByIdQuery(string tourId)
        {
            this.TourId = tourId;
        }

        public string TourId { get; set; }
    }
}
