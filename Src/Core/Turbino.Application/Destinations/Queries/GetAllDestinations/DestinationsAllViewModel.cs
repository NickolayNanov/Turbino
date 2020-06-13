namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    using AutoMapper;

    using Turbino.Domain.Entities;
    using Turbino.Application.Interfaces.Mapping;

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
