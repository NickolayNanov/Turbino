namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Turbino.Domain.Common;
    using Turbino.Domain.Entities;
    using Turbino.Application.Common.Interfaces;
    using Turbino.Application.Destinations.Queries.GetAllDestinations;

    using MediatR;
    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Results;
    using CloudinaryDotNet.Actions;

    public class GetAllDestinationsWithFilterHandler : IRequestHandler<GetAllDestinationsWithFilterQuery, GetAllDestinationsWithFilterListViewModel>
    {
        private const int PageSize = 12;
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;
        private readonly IValidator<GetAllDestinationsWithFilterQuery> validator;

        public GetAllDestinationsWithFilterHandler(ITurbinoDbContext context, IMapper mapper, IValidator<GetAllDestinationsWithFilterQuery> validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<GetAllDestinationsWithFilterListViewModel> Handle(GetAllDestinationsWithFilterQuery request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await validator.ValidateAsync(request);

            if (validation.IsValid)
            {

                return new GetAllDestinationsWithFilterListViewModel()
                {
                    Destinations = await this.mapper
                                                .ProjectTo<DestinationsAllListModel>(
                                                    PaginatedList<Destination>.Create(this.context.Destinations
                                                                                        .AsNoTracking()
                                                                                        .Where(d => d.Name.ToLower().StartsWith(request.DestinationName.ToLower())),
                                                                                      request.PageIndex ?? 1, PageSize)).ToListAsync(),
                    PageIndex = request.PageIndex ?? 0,
                    SearchQuery = request.DestinationName,
                    HaveMoreDestinations = context.Destinations.Where(d => d.Name.StartsWith(request.DestinationName)).Count() > (request.PageIndex ?? 1) * PageSize
                };
            }
            else
            {
                return new GetAllDestinationsWithFilterListViewModel()
                {
                    Destinations = new List<DestinationsAllListModel>(),
                    PageIndex = request.PageIndex ?? 0,
                    SearchQuery = request.DestinationName,
                    HaveMoreDestinations = context.Destinations.Where(d => d.Name.StartsWith(request.DestinationName)).Count() > (request.PageIndex ?? 1) * PageSize,
                    Errors = validation.Errors.Select(x => x.ErrorMessage).ToArray()
                };
            }
        }
    }
}
