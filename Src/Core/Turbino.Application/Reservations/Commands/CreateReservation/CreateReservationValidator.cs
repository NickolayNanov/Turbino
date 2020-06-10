using FluentValidation;
using System;
using Turbino.Domain.Interfaces;

namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            RuleFor(r => r.ReserverName)
                .NotNull()
                .WithMessage("Your name must not be empty!");

            RuleFor(r => r.DateOfLeaving)
                .NotNull()
                .WithMessage("The date of leaving is requried!");

            RuleFor(r => r.ArrivalDate)
                .NotNull()
                .WithMessage("The arrival date is requried!");

            RuleFor(r => r.ArrivalDate)
                .LessThan(r => r.DateOfLeaving)
                .When(r => r.ArrivalDate != null && r.DateOfLeaving != null)
                .WithMessage("The date of the arrival must be before the living date!");

        }
    }
}
