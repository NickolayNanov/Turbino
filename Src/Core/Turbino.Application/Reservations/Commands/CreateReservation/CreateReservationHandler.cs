using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FluentValidation;

namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, string[]>
    {
        private readonly ITurbinoDbContext context;
        private readonly IValidator<CreateReservationCommand> validator;
        private readonly UserManager<TurbinoUser> userManager;

        public CreateReservationHandler(ITurbinoDbContext context, IValidator<CreateReservationCommand> validator, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.validator = validator;
        }

        public async Task<string[]> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            var result = await validator.ValidateAsync(request);

            if (result.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    UserId = user.Id,
                    TourId = request.TourId,
                    DateOfLeaving = request.DateOfLeaving.Value,
                    DepartureDate = request.ArrivalDate.Value
                };

                var id = context.Reservations.Add(reservation).Entity.Id;
                await context.SaveChangesAsync(cancellationToken);

                return null;
            }

            return result.Errors.Select(e => e.ErrorMessage).ToArray();
        }
    }
}
