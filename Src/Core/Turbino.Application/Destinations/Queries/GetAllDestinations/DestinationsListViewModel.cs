using System.Collections.Generic;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationsListViewModel
    {
        public DestinationsListViewModel()
        {
            this.PageIndex = 1;
        }

        public IList<DestinationsAllListModel> Destinations { get; set; }

        public int? PageIndex { get; set; } = 1;

        public string SearchQuery { get; set; }

        public string PriceRange { get; set; }

        public bool HaveMoreDestinations { get; set; }
    }
}
