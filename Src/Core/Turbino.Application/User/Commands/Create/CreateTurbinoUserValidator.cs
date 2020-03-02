using FluentValidation;

namespace Turbino.Application.User.Commands.Create
{
    public class CreateTurbinoUserValidator : AbstractValidator<CreateTurbinoUserCommand>
    {
        public CreateTurbinoUserValidator()
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}
