namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    using System.Collections.Generic;

    public class GetAllToursListViewModel
    {
        public GetAllToursListViewModel()
        {
            this.PageIndex = 1;
            Errors = new string[0];
        }

        public string TourName { get; set; }

        public string Month { get; set; }

        public string TourType { get; set; }

        public int SortOrder { get; set; }

        public string DestinationName { get; set; }

        public string PriceStr { get; set; }

        public int? PageIndex { get; set; }

        public bool HaveMoreTours { get; set; }

        public string[] Errors { get; set; }

        public IList<GetAllToursListModel> Tours { get; set; }
    }
}
