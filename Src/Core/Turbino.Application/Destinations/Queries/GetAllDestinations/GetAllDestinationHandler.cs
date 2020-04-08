using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Common;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetAllDestinations
{
    public class GetAllDestinationHandler : IRequestHandler<GetAllDestinationsListQuery, DestinationsListViewModel>
    {
        private readonly IMapper mapper;
        private readonly ITurbinoDbContext context;

        public GetAllDestinationHandler(IMapper mapper, ITurbinoDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<DestinationsListViewModel> Handle(GetAllDestinationsListQuery request, CancellationToken cancellationToken)
        {
            return new DestinationsListViewModel
            {
                Destinations = await this.mapper
                                        .ProjectTo<DestinationsAllListModel>(
                                             PaginatedList<Destination>.Create(context.Destinations.AsNoTracking(), request.PageIndex ?? 1, 12)).ToListAsync(),
                PageIndex = request.PageIndex ?? 0,
                HaveMoreDestinations = context.Destinations.Count() > (request.PageIndex ?? 1) * 12
            };
        } 
    }
}
