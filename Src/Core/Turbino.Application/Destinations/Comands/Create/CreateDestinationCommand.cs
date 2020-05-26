using MediatR;
using Microsoft.AspNetCore.Http;

namespace Turbino.Application.Destinations.Commands.Create
{
    public class CreateDestinationCommand : IRequest
    {
        public CreateDestinationCommand()
        {
            
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SpokenLanguage { get; set; }

        public string Visa { get; set; }

        public string Currency { get; set; }

        public int? SquareArea { get; set; }

        public IFormFile ImgUrl { get; set; }

        public IFormFile FirstImg { get; set; }

        public IFormFile SecondImg { get; set; }

        public string DestinationNameHeader { get; set; }
        public string DestinationNameParagraph { get; set; }

        public string DestinationFirstHeader { get; set; }
        public string DestinationFirstParagraph { get; set; }

        public string DestinationSecondHeader { get; set; }
        public string DestinationSecondParagraph { get; set; }

        public string DestinationThirdHeader { get; set; }
        public string DestinationThirdParagraph { get; set; }

        public string DestinationForthHeader { get; set; }
        public string DestinationForthParagraph { get; set; }

        public string DestinationFifthHeader { get; set; }
        public string DestinationFifthParagraph { get; set; }
    }
}
