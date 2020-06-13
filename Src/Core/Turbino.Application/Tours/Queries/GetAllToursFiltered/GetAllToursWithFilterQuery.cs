namespace Turbino.Application.Tours.Queries.GetAllToursFiltered
{
    using MediatR;

    public class GetAllToursWithFilterQuery : IRequest<GetAllToursWithFilterListViewModel>
    {
        public GetAllToursWithFilterQuery()
        {
            this.PageIndex = 1;
        }

        public string TourName { get; set; }

        public string Month { get; set; }

        public string TourType { get; set; }

        public int SortOrder { get; set; }

        public string DestinationName { get; set; }

        public string PriceStr { get; set; }

        public int? PageIndex { get; set; }

        public bool HaveMoreTours { get; set; }
    }
}
