using AutoMapper;
using System.Collections.Generic;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationsListViewModel
    {
        public DestinationsListViewModel()
        {
            this.Filter = new Filter();
        }

        public IList<DestinationsAllListModel> Destinations { get; set; }

        public Filter Filter { get; set; }

        public int PageIndex { get; set; } = 1;
    }

    public class Filter 
    {
        public string SearchQuery { get; set; }

        public string Month { get; set; }

        public string TourType { get; set; }

        public string SortOrder { get; set; }

        public string PriceRange { get; set; }
    }
}
