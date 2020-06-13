namespace Turbino.Application.Reservations.Queries.GetAllReservationsByUser
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Turbino.Domain.Entities;
    using Turbino.Application.Common.Interfaces;

    using MediatR;
    using AutoMapper;

    public class GetAllReservationsByUserHandler : IRequestHandler<GetAllReservationsByUserQuery, GetAllReservationsByUserList>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<TurbinoUser> userManager;

        public GetAllReservationsByUserHandler(ITurbinoDbContext context, IMapper mapper, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<GetAllReservationsByUserList> Handle(GetAllReservationsByUserQuery request, CancellationToken cancellationToken)
        {
            TurbinoUser user = await userManager.FindByNameAsync(request.Username);

            return new GetAllReservationsByUserList
            {
                Reservations = await mapper.ProjectTo<GetAllReservationsByUserViewModel>(context.Reservations
                                                                                                    .Include(r => r.Tour)
                                                                                                        .ThenInclude(t => t.Destination)
                                                                                                    .Where(x => x.UserId == user.Id))
                                                                                                    .ToListAsync()
            };
        }
    }
}
