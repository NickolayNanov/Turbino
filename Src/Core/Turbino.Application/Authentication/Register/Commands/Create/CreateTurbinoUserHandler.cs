using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Domain.Entities;

namespace Turbino.Application.Authentication.Register.Commands.Create
{
    public class CreateTurbinoUserHandler : IRequestHandler<CreateTurbinoUserCommand, Unit>
    {
        private readonly UserManager<TurbinoUser> userManager;
        private readonly SignInManager<TurbinoUser> signInManager;

        public CreateTurbinoUserHandler(UserManager<TurbinoUser> userManager, SignInManager<TurbinoUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Unit> Handle(CreateTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            TurbinoUser user = new TurbinoUser()
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                FullName = request.FirstName,
                UserName = request.Username
            };

            await userManager.CreateAsync(user, request.Password);
            await userManager.AddToRoleAsync(user, "User");
            await signInManager.SignInAsync(user, true);
            return Unit.Value;
        }
    }
}
