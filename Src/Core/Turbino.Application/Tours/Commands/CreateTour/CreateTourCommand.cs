using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Turbino.Application.Interfaces.Mapping;
using Turbino.Domain.Entities;

namespace Turbino.Application.Tours.Commands.CreateTour
{
    public class CreateTourCommand : IRequest, IHaveCustomMapping
    {
        public string Name { get; set; }

        public decimal? PricePerPerson { get; set; }

        public int? RequiredAge { get; set; }

        public int? Duration { get; set; }

        public IEnumerable<DestinationDto> Destinations { get; set; }

        public string Location { get; set; }

        public string TourType { get; set; }

        public string Dates { get; set; }

        public string Departure { get; set; }

        public string NextDeparture { get; set; }

        public string Accommodation { get; set; }

        public List<string> Included { get; set; }

        public IEnumerable<string> IncludeOptions { get; set; }

        public IEnumerable<string> NotIncludeOption { get; set; }

        public List<string> NotIncluded { get; set; }

        public string MainHeader { get; set; }
        public string MainHeaderParagraph { get; set; }

        public string FirstHeader { get; set; }
        public string FirstHeaderParagraph { get; set; }

        public string SecondHeader { get; set; }
        public string SecondHeaderParagraph { get; set; }

        public string ThirdHeader { get; set; }
        public string ThirdHeaderParagraph { get; set; }

        public string ForthHeader { get; set; }
        public string ForthHeaderParagraph { get; set; }

        public string FifthHeader { get; set; }
        public string FifthHeaderParagraph { get; set; }

        public string SixthHeader { get; set; }
        public string SixthHeaderParagraph { get; set; }

        public IFormFile FirstImg { get; set; }

        public IFormFile SecondImg { get; set; }

        public IFormFile MainImg { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Tour, CreateTourCommand>().ReverseMap();                
        }
    }

    public class DestinationDto
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
