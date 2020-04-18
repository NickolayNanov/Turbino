using FluentValidation;
using Turbino.Common.GlobalContants;

namespace Turbino.Application.Tours.Commands.CreateTour
{
    public class CreateTourValidator : AbstractValidator<CreateTourCommand>
    {
        public CreateTourValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Name)));

            RuleFor(t => t.PricePerPerson)
                .Must(x => x > 0)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateTourCommand.PricePerPerson)));

            RuleFor(t => t.RequiredAge)
                .Must(x => x > 0)
                .Must(x => x < 100)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateTourCommand.RequiredAge)));

            RuleFor(t => t.Duration)
                .Must(x => x > 0)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Duration)));

            RuleFor(t => t.Location)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Location)));

            RuleFor(t => t.Dates)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Dates)));

            RuleFor(t => t.Departure)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Departure)));

            RuleForEach(t => t.NextDeparture)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.NextDeparture)));
            
            RuleForEach(t => t.Accommodation)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Accommodation)));

            RuleForEach(t => t.Included)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Included)));

            RuleForEach(t => t.NotIncluded)
                .NotEmpty()
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.NotIncluded)));

        }
    }
}
