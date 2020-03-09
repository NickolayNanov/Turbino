using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;

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
            => new DestinationsListViewModel
            {
                Destinations = await context.Destinations.ProjectTo<DestinationsAllListModel>(this.mapper.ConfigurationProvider)
                                                         .ToListAsync()
            };
    }
}
