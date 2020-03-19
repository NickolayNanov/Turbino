using AutoMapper;
using System.Collections.Generic;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationsListViewModel
    {
        public IList<DestinationsAllListModel> Destinations { get; set; }

        public int PageIndex { get; set; } = 1;
    }
}
