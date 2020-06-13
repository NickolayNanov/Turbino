namespace Turbino.Application.Authentication.Login.Commands
{
    using FluentValidation;
    using Turbino.Common.GlobalContants;

    public class LoginTurbinoUserValidator : AbstractValidator<LoginTurbinoUserCommand>
    {
        public LoginTurbinoUserValidator()
        {
            RuleFor(l => l.Username)
                .NotNull()
                 .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(LoginTurbinoUserCommand.Username)));

            RuleFor(l => l.Password)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(LoginTurbinoUserCommand.Password)));
        }
    }
}
