namespace Turbino.Application.Authentication.Login.Commands
{
    using FluentValidation;

    public class LoginTurbinoUserValidator : AbstractValidator<LoginTurbinoUserCommand>
    {
        public LoginTurbinoUserValidator()
        {
            RuleFor(l => l.Username)
                .NotNull();

            RuleFor(l => l.Password)
                .NotNull();
        }
    }
}
