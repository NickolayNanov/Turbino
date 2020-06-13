namespace Turbino.Application.Seed
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using MediatR;

    using Common.Interfaces;
    using Turbino.Domain.Entities;


    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ITurbinoDbContext context;
        private readonly RoleManager<TurbinoRole> roleManager;
        private readonly UserManager<TurbinoUser> userManager;

        public SeedSampleDataCommandHandler(ITurbinoDbContext context, RoleManager<TurbinoRole> roleManager, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            SampleDataSeeder seeder = new SampleDataSeeder(context, roleManager, userManager);
            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
