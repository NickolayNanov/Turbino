using FluentValidation;

namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Your name must not be empty!");

            RuleFor(r => r.DepartureDate)
                .NotNull()
                .NotEmpty()
                .LessThan(r => r.DateOfLeaving)
                .WithMessage("The departure date is required and must be before the leaving date!");

            RuleFor(r => r.DateOfLeaving)
                .NotNull()
                .NotEmpty()
                .GreaterThan(r => r.DepartureDate)
                .WithMessage("The date of leaving is requried and must be greater than the departure date!");
        }
    }
}
