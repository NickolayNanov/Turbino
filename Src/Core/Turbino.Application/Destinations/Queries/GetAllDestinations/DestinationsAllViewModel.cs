using AutoMapper;
using System.Collections.Generic;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class DestinationsAllListModel : IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Destination, DestinationsAllListModel>();
        }       
    }
}
