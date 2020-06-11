using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Domain.Entities;

namespace Turbino.Application.Authentication.Login.Commands
{
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
            var validation = await validator.ValidateAsync(request);
            if (validation.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
                if (!result.Succeeded)
                {
                    return new string[] { "Invalid username or password!" };
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
