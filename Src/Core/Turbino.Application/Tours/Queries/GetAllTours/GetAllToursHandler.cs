using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Common;
using Turbino.Domain.Entities;

namespace Turbino.Application.Tours.Queries.GetAllDestinations
{
    public class GetAllToursHandler : IRequestHandler<GetAllToursListQuery, GetAllToursListViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetAllToursHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetAllToursListViewModel> Handle(GetAllToursListQuery request, CancellationToken cancellationToken)
        {
            return new GetAllToursListViewModel()
            {
                Tours = await this.mapper
                                    .ProjectTo<GetAllToursListModel>(
                                        PaginatedList<Tour>.Create(context.Tours.AsNoTracking(), request.PageIndex ?? 1, 12))
                                            .ToListAsync(),
                PageIndex = request.PageIndex,
                HaveMoreTours = context.Tours.Count() > (request.PageIndex ?? 1) * 12
            };
        }
    }
}
