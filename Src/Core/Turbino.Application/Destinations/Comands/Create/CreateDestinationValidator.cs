using FluentValidation;
using Turbino.Common.GlobalContants;

namespace Turbino.Application.Destinations.Commands.Create
{
    public class CreateDestinationValidator : AbstractValidator<CreateDestinationCommand>
    {
        public CreateDestinationValidator()
        {
            RuleFor(d => d.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(70)
                .WithMessage(string.Format(ApplicationConstants.NumberBetweenErrorMsg, nameof(CreateDestinationCommand.Name), 3, 70));

            RuleFor(d => d.SpokenLanguage)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.SpokenLanguage)));

            RuleFor(d => d.Currency)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.Currency)));

            RuleFor(d => d.Visa)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.Visa)));

            RuleFor(d => d.SquareArea)
                .GreaterThan(0)
                .WithMessage(string.Format(ApplicationConstants.PositiveNumberErrorMsg, nameof(CreateDestinationCommand.SquareArea)));

            RuleFor(d => d.DestinationFirstHeader)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationFirstHeader)));

            RuleFor(d => d.DestinationFirstParagraph)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationFirstParagraph)));

            RuleFor(d => d.DestinationSecondHeader)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationSecondHeader)));

            RuleFor(d => d.DestinationNameParagraph)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationNameParagraph)));

            RuleFor(d => d.DestinationThirdHeader)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationThirdHeader)));

            RuleFor(d => d.DestinationThirdParagraph)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationThirdParagraph)));

            RuleFor(d => d.DestinationForthHeader)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationForthHeader)));

            RuleFor(d => d.DestinationForthParagraph)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationForthParagraph)));

            RuleFor(d => d.DestinationFirstHeader)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationFirstHeader)));

            RuleFor(d => d.DestinationFifthParagraph)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateDestinationCommand.DestinationFifthParagraph)));
        }
    }
}
