using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;

namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly UserManager<TurbinoUser> userManager;

        public CreateReservationHandler(ITurbinoDbContext context, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);

            Reservation reservation = new Reservation()
            {
                UserId = user.Id,
                TourId = request.TourId,
                DateOfLeaving = request.DateOfLeaving,
                DepartureDate = request.DepartureDate
            };

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
