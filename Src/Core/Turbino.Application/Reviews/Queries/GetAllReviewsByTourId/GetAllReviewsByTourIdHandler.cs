namespace Turbino.Application.Reviews.Queries.GetAllReviewsByTourId
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Turbino.Application.Common.Interfaces;

    using MediatR;
    using AutoMapper;


    public class GetAllReviewsByTourIdHandler : IRequestHandler<GetAllReviewsByTourIdQuery, GetAllReviewsByTourIdListViewModel>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;

        public GetAllReviewsByTourIdHandler(ITurbinoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GetAllReviewsByTourIdListViewModel> Handle(GetAllReviewsByTourIdQuery request, CancellationToken cancellationToken)
        {
            return new GetAllReviewsByTourIdListViewModel
            {
                Reviews = await mapper.ProjectTo<GetAllReviewsByTourIdViewModel>(context.Reviews.Include(x => x.Author)
                                                                                                .Where(r => r.TourId == request.TourId))
                                                                                                .ToListAsync()
            };
        }
    }
}
