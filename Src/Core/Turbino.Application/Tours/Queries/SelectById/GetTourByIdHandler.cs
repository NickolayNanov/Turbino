﻿namespace Turbino.Application.Tours.Queries.SelectById
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Turbino.Application.Common.Interfaces;
    using Turbino.Application.Reviews.Queries.GetAllReviewsByTourId;
    using Turbino.Domain.Entities;

    public class GetTourByIdHandler : IRequestHandler<GetTourByIdQuery, TourViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMediator mediator;

        public GetTourByIdHandler(ITurbinoDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<TourViewModel> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            Tour tour = await context.Tours.FindAsync(request.TourId);
            Destination destination = await context.Destinations.FindAsync(tour.DestinationId);

            TourViewModel model = new TourViewModel()
            {
                Id = request.TourId,
                Name = tour.Name,
                Departure = tour.Departure,
                Accommodation = tour.Accommodation,
                NextDeparture = tour.NextDeparture,
                Description = destination.Description,
                Dates = tour.Dates,
                Duration = tour.Duration,
                Location = tour.Location,
                PricePerPerson = tour.PricePerPerson,
                RequiredAge = tour.RequiredAge,
                TourType = tour.TourType.ToString(),
                Included = tour.Included.Split(", ").ToList(),
                NotIncluded = tour.NotIncluded.Split(", ").ToList(),
                Reviews = await mediator.Send(new GetAllReviewsByTourIdQuery() { TourId = tour.Id })
            };

            return model;
        }
    }
}
