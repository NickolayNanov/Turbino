namespace Turbino.Application.Reservations.Commands.CreateReservation
{
    using FluentValidation;
    using Turbino.Common.GlobalContants;

    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        private const string DatesValidationMessage = "The date of the arrival must be before the living date!";

        public CreateReservationValidator()
        {
            RuleFor(r => r.ReserverName)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateReservationCommand.ReserverName)));

            RuleFor(r => r.DateOfLeaving)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateReservationCommand.DateOfLeaving)));

            RuleFor(r => r.ArrivalDate)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateReservationCommand.ArrivalDate)));

            RuleFor(r => r.ArrivalDate)
                .LessThan(r => r.DateOfLeaving)
                .When(r => r.ArrivalDate != null && r.DateOfLeaving != null)
                .WithMessage(DatesValidationMessage);
        }
    }
}
