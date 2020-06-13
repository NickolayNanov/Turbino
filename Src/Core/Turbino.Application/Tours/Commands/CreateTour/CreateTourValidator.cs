namespace Turbino.Application.Tours.Commands.CreateTour
{
    using FluentValidation;

    using Turbino.Common.GlobalContants;

    public class CreateTourValidator : AbstractValidator<CreateTourCommand>
    {
        public CreateTourValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Name)));

            RuleFor(t => t.PricePerPerson)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateTourCommand.PricePerPerson)));

            RuleFor(t => t.RequiredAge)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.RequiredAge)));

            RuleFor(t => t.RequiredAge)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100)
                .When(x => x.RequiredAge.HasValue)
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateTourCommand.RequiredAge)));

            RuleFor(t => t.Duration)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Duration)));

            RuleFor(t => t.Duration)
                .GreaterThan(0)
                .When(x => x.Duration.HasValue)
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateTourCommand.Duration)));

            RuleFor(t => t.Location)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Location)));

            RuleFor(t => t.Dates)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Dates)));

            RuleFor(t => t.Departure)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Departure)));

            RuleForEach(t => t.NextDeparture)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.NextDeparture)));
            
            RuleForEach(t => t.Accommodation)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Accommodation)));

            RuleForEach(t => t.Included)
                .Must(x => x.Length > 0)
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.Included)));

            RuleForEach(t => t.NotIncluded)
                .Must(x => x.Length > 0)
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTourCommand.NotIncluded)));

        }
    }
}
