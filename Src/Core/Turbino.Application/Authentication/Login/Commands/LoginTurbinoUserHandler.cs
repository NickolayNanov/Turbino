using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Domain.Entities;

namespace Turbino.Application.Authentication.Login.Commands
{
    public class LoginTurbinoUserHandler : IRequestHandler<LoginTurbinoUserCommand, string>
    {
        private readonly SignInManager<TurbinoUser> signInManager;
        private readonly UserManager<TurbinoUser> userManager;

        public LoginTurbinoUserHandler(SignInManager<TurbinoUser> signInManager, UserManager<TurbinoUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<string> Handle(LoginTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
            }
            catch
            {
                return "Invalid login attempt!";
            }

            return string.Empty;
        }
    }
}
