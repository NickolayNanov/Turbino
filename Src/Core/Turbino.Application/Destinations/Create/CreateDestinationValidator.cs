using FluentValidation;

namespace Turbino.Application.Destinations.Create
{
    public class CreateDestinationValidator : AbstractValidator<CreateDestinationCommand>
    {
        public CreateDestinationValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(70);

            RuleFor(d => d.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(255);

            RuleFor(d => d.SpokenLanguage)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(d => d.Visa)
                .NotNull()
                .NotEmpty();

            RuleFor(d => d.Currency)
                .NotNull()
                .NotEmpty();

            RuleFor(d => d.SquareArea)
                .Must(x => x > 0);

        }
    }
}
