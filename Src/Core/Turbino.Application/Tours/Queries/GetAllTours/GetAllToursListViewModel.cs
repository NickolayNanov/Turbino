using System.Collections.Generic;
using Turbino.Application.Tours.Queries.GetAllToursFiltered;

namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    public class GetAllToursListViewModel
    {
        public GetAllToursListViewModel()
        {
            this.PageIndex = 1;
            Errors = new string[0];
        }

        public IList<GetAllToursListModel> Tours { get; set; }

        public string TourName { get; set; }

        public string Month { get; set; }

        public string TourType { get; set; }

        public int SortOrder { get; set; }

        public string DestinationName { get; set; }

        public string PriceStr { get; set; }

        public int? PageIndex { get; set; }

        public bool HaveMoreTours { get; set; }

        public string[] Errors { get; set; }
    }
}
