using System.Collections.Generic;
using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Application.Tours.Queries.GetAllDestinations;

namespace Turbino.Application.Home.Queries.GetIndex
{
    public class IndexHolderViewModel
    {
        public GetAllToursListViewModel TourViewModel { get; set; }

        public DestinationsListViewModel Destinations { get; set; }


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
