using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;
using Turbino.Domain.Enumerations;
using Turbino.Infrastructure;

namespace Turbino.Application.Tours.Commands.CreateTour
{
    public class CreateTourHandler : IRequestHandler<CreateTourCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;
        private readonly ImageUploader imageUploader;

        public CreateTourHandler(ITurbinoDbContext context, IMapper mapper, ImageUploader imageUploader)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageUploader = imageUploader;
        }

        public async Task<Unit> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var destination = await context.Destinations.FindAsync(request.Location);
            string[] imgUrls = new string[]
            {
                imageUploader.UploadImage(request.FirstImg, Guid.NewGuid().ToString()),
                imageUploader.UploadImage(request.SecondImg, Guid.NewGuid().ToString()),
                imageUploader.UploadImage(request.MainImg, Guid.NewGuid().ToString())
            };

            Tour tour = mapper.Map<Tour>(request);
            tour.ImgUrl = imgUrls[0];
            tour.Description = GetDesctiption(request, imgUrls);
            tour.Included = string.Join(", ", request.Included);
            tour.NotIncluded = string.Join(", ", request.NotIncluded);
            tour.DestinationId = request.Location;
            tour.TourType = Enum.Parse<TourType>(request.TourType);
            tour.Location = destination.Name;

            context.Tours.Add(tour);
            await context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        private string GetDesctiption(CreateTourCommand request, string[] imgUrls)
        {
            return $"<div><div class=\"tour-schedule\"><h6 class=\"black bold mt-4 mb-3\">{request.MainHeader}</h6><p>{request.MainHeaderParagraph}</p><div class=\"list-font semibold mt-3\">{request.FirstHeader}</div><p>{request.FirstHeaderParagraph}</p><div class=\"list-font semibold mt-3\">{request.SecondHeader}</div><p>{request.SecondHeaderParagraph}</p><img class=\"img-fluid my-3\" src=\"{imgUrls[1]}\" alt=\"\"> <h6 class=\"black bold mt-5 mb-3\">{request.ThirdHeader}</h6><p>{request.ThirdHeaderParagraph}</p><div class=\"list-font semibold mt-3\">{request.ForthHeader}</div><p>{request.ForthHeaderParagraph}</p><img class=\"img-fluid my-3\" src=\"{imgUrls[2]}\" alt=\"\"><div class=\"list-font semibold mt-3\">{request.FifthHeader}</div><p>{request.FifthHeaderParagraph}</p><div class=\"list-font semibold mt-3\">{request.SixthHeader}</div><p>{request.SixthHeaderParagraph}</p></div></div>";
        }
    }
}
