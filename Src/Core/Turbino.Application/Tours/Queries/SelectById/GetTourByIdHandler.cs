using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Application.Tours.Commands.CreateTour;

namespace Turbino.Application.Tours.Queries.SelectById
{
    public class GetTourByIdHandler : IRequestHandler<GetTourByIdQuery, TourViewModel>
    {
        private readonly ITurbinoDbContext context;

        public GetTourByIdHandler(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public async Task<TourViewModel> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            var tour = await context.Tours.FindAsync(request.TourId);
            var destination = await context.Destinations.FindAsync(tour.DestinationId);

            TourViewModel model = new TourViewModel()
            {
                Name = tour.Name,
                Departure = tour.Departure,
                Accommodation = tour.Accommodation,
                NextDeparture = tour.NextDeparture,
                Description = destination.Name,
                Dates = tour.Dates,
                Duration = tour.Duration,
                Included = tour.Included.Split(", ").ToList(),
                NotIncluded = tour.NotIncluded.Split(", ").ToList(),
                Location = tour.Location,
                PricePerPerson = tour.PricePerPerson,
                RequiredAge = tour.RequiredAge,
                TourType = tour.TourType.ToString(),
            };

            return model;
        }
    }
}
