using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Application.Tours.Queries.GetAllDestinations;

namespace Turbino.Application.Home.Queries.GetIndex
{
    public class IndexHolderViewModel
    {
        public GetAllToursListViewModel TourViewModel { get; set; }

        public DestinationsListViewModel Destinations { get; set; }
    }
}
