using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Application.Destinations.Queries.GetAllDestinations;
using Turbino.Application.Tours.Queries.GetAllDestinations;

namespace Turbino.Application.Home.Queries.GetIndex
{
    public class GetIndexHandler : IRequestHandler<GetIndexQuery, IndexHolderViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetIndexHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IndexHolderViewModel> Handle(GetIndexQuery request, CancellationToken cancellationToken)
        {
            return new IndexHolderViewModel()
            {
                TourViewModel = new GetAllToursListViewModel()
                {
                    Tours = await this.mapper
                                    .ProjectTo<GetAllToursListModel>(context.Tours.OrderByDescending(t => t.Rating).Take(6))
                                            .ToListAsync()
                },
                Destinations = new DestinationsListViewModel()
                {
                    Destinations = await this.mapper
                                        .ProjectTo<DestinationsAllListModel>(context.Destinations.OrderByDescending(d => d.TimesVisited).Take(6).AsNoTracking())
                                            .ToListAsync()
                }
            };
        }
    }
}
