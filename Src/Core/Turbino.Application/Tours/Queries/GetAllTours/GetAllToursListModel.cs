namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    using System.Linq;

    using Turbino.Domain.Entities;
    using Turbino.Application.Interfaces.Mapping;

    using AutoMapper;

    public class GetAllToursListModel : IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public int Reviews { get; set; }

        public int Rating { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Tour, GetAllToursListModel>()
                .ForMember(x => x.Price, y => y.MapFrom(z => z.PricePerPerson))
                .ForMember(x => x.Rating, y => y.MapFrom(z => (int)z.Reviews.Average(r => (int)r.Rating)))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews.Count))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.TourType.ToString()))
                .ForMember(x => x.Description, y => y.MapFrom(z => string.Join("", z.Description.Take(30))));
        }
    }
}
