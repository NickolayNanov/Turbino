namespace Turbino.Application.Authentication.Register.Commands.Create
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Domain.Entities;

    using MediatR;
    using FluentValidation;
    using FluentValidation.Results;
    public class CreateTurbinoUserHandler : IRequestHandler<CreateTurbinoUserCommand, string[]>
    {
        private const string UserRole = "User";
        private readonly UserManager<TurbinoUser> userManager;
        private readonly SignInManager<TurbinoUser> signInManager;
        private readonly IValidator<CreateTurbinoUserCommand> validator;

        public CreateTurbinoUserHandler(UserManager<TurbinoUser> userManager, SignInManager<TurbinoUser> signInManager, IValidator<CreateTurbinoUserCommand> validator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.validator = validator;
        }

        public async Task<string[]> Handle(CreateTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                return validation.Errors.Select(x => x.ErrorMessage).ToArray();
            }

            TurbinoUser user = new TurbinoUser()
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                FullName = request.FirstName,
                UserName = request.Username
            };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, UserRole);
                await signInManager.SignInAsync(user, true);
            }
            else
            {
                return result.Errors.Select(x => x.Description).ToArray();
            }
      
            return new string[0];
        }
}
}
