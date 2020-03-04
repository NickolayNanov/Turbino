using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Domain.Entities;

namespace Turbino.Application.Authentication.Login.Commands
{
    public class LoginTurbinoUserHandler : IRequestHandler<LoginTurbinoUserCommand, Unit>
    {
        private readonly SignInManager<TurbinoUser> signInManager;
        private readonly UserManager<TurbinoUser> userManager;

        public LoginTurbinoUserHandler(SignInManager<TurbinoUser> signInManager, UserManager<TurbinoUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(LoginTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            var asd = await signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);
            return Unit.Value;
        }
    }
}
