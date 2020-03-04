using FluentValidation;

namespace Turbino.Application.Authentication.Register.Commands.Create
{
    public class CreateTurbinoUserValidator : AbstractValidator<CreateTurbinoUserCommand>
    {
        public CreateTurbinoUserValidator()
        {
            RuleFor(c => c.Username)
                   .NotNull()
                   .NotEmpty()
                   .MaximumLength(30);

            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(c => c.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(c => c.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .Equal(c => c.Password)
                .MinimumLength(6);
        }
    }
}
