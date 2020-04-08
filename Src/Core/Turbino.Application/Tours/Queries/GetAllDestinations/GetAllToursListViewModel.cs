using System.Collections.Generic;

namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    public class GetAllToursListViewModel
    {
        public GetAllToursListViewModel()
        {
            this.PageIndex = 1;
        }

        public IList<GetAllToursListModel> Tours { get; set; }

        public string SearchQuery { get; set; }

        public string Month { get; set; }

        public string TourType { get; set; }

        public string Destination { get; set; }
        
        public int SortingOrder { get; set; }

        public string PriceRange { get; set; }

        public int? PageIndex { get; set; }

        public bool HaveMoreTours { get; set; }
    }
}
