using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Domain.Common;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    public class GetAllDestinationsWithFilterHandler : IRequestHandler<GetAllDestinationsWithFilterQuery, GetAllDestinationsWithFilterListViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetAllDestinationsWithFilterHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetAllDestinationsWithFilterListViewModel> Handle(GetAllDestinationsWithFilterQuery request, CancellationToken cancellationToken)
        {
            return new GetAllDestinationsWithFilterListViewModel()
            {
                Destinations = await this.mapper
                                            .ProjectTo<DestinationsAllListModel>(
                                                PaginatedList<Destination>.Create(this.context.Destinations
                                                                                    .AsNoTracking()
                                                                                    .Where(d => d.Name.ToLower().StartsWith(request.DestinationName.ToLower())),
                                                                                  request.PageIndex ?? 1, 12)).ToListAsync(),
                PageIndex = request.PageIndex ?? 0,
                SearchQuery = request.DestinationName,
                HaveMoreDestinations = context.Destinations.Where(d => d.Name.StartsWith(request.DestinationName)).Count() > (request.PageIndex ?? 1) * 12
            };
        }
    }
}
