namespace Turbino.Application.Authentication.Login.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Domain.Entities;
    using Turbino.Common.GlobalContants;

    using MediatR;
    using FluentValidation;
    using FluentValidation.Results;

    public class LoginTurbinoUserHandler : IRequestHandler<LoginTurbinoUserCommand, string[]>
    {
        private readonly SignInManager<TurbinoUser> signInManager;
        private readonly UserManager<TurbinoUser> userManager;
        private readonly IValidator<LoginTurbinoUserCommand> validator;

        public LoginTurbinoUserHandler(SignInManager<TurbinoUser> signInManager, UserManager<TurbinoUser> userManager, IValidator<LoginTurbinoUserCommand> validator)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.validator = validator;
        }

        public async Task<string[]> Handle(LoginTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await validator.ValidateAsync(request);

            if (validation.IsValid)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

                if (!result.Succeeded)
                {
                    return new string[] { WebConstants.InvalidLoginAttempt };
                }
            }
            else
            {
                return validation.Errors.Select(x => x.ErrorMessage).ToArray();
            }

            return new string[0];
        }
    }
}
