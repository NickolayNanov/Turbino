namespace Turbino.Application.Home.Commands.UpdateUserProfile
{
    using FluentValidation;
    using Turbino.Common.GlobalContants;
    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(UpdateUserProfileCommand.FirstName)));

            RuleFor(p => p.LastName)
                .NotNull()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(UpdateUserProfileCommand.LastName)));
        }
    }
}
