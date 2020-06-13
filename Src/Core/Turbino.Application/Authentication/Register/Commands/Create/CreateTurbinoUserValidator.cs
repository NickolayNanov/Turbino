namespace Turbino.Application.Authentication.Register.Commands.Create
{
    using FluentValidation;

    using Turbino.Common.GlobalContants;

    public class CreateTurbinoUserValidator : AbstractValidator<CreateTurbinoUserCommand>
    {
        public CreateTurbinoUserValidator()
        {
            RuleFor(c => c.Username)
                   .NotEmpty()
                   .MaximumLength(30)
                   .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTurbinoUserCommand.Username)));

            RuleFor(c => c.Username)
                .MaximumLength(20)
                .When(x => !string.IsNullOrEmpty(x.Username))
                .WithMessage(string.Format(ApplicationConstants.NumberBetweenErrorMsg, nameof(CreateTurbinoUserCommand.Username), 0, 20));

            RuleFor(c => c.FirstName)
                .MaximumLength(30)
                .When(x => !string.IsNullOrEmpty(x.FirstName))
                .WithMessage(string.Format(ApplicationConstants.NumberBetweenErrorMsg, nameof(CreateTurbinoUserCommand.FirstName), 0, 30));

            RuleFor(c => c.FirstName)
                  .NotEmpty()
                  .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTurbinoUserCommand.FirstName)));

            RuleFor(c => c.LastName)
                   .NotEmpty()
                   .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTurbinoUserCommand.LastName)));

            RuleFor(c => c.LastName)
                .MaximumLength(20)
                .When(x => !string.IsNullOrEmpty(x.LastName))
                .WithMessage(string.Format(ApplicationConstants.NumberBetweenErrorMsg, nameof(CreateTurbinoUserCommand.LastName), 0, 20));

            RuleFor(c => c.Password)
                   .NotEmpty()
                   .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTurbinoUserCommand.Password)));

            RuleFor(c => c.Password)
                .MinimumLength(6)
                .When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage(string.Format(WebConstants.InvalidPasswordLength));

            RuleFor(c => c.ConfirmPassword)
                .MinimumLength(6)
                .When(x => !string.IsNullOrEmpty(x.ConfirmPassword))
                .WithMessage(string.Format(WebConstants.InvalidConfirmPasswordLength));

            RuleFor(c => c.ConfirmPassword)
                .NotNull()
                .WithMessage(string.Format(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(CreateTurbinoUserCommand.Password))));

            RuleFor(c => c.ConfirmPassword)
                .Equal(c => c.Password)
                .When(x => string.IsNullOrEmpty(x.ConfirmPassword))
                .WithMessage(WebConstants.NotEqualPasswords);
        }
    }
}
