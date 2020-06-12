namespace Turbino.Application.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Turbino.Common.GlobalContants;
    using Turbino.Domain.Entities;

    public class SampleDataSeeder
    {
        private readonly ITurbinoDbContext context;
        private readonly UserManager<TurbinoUser> userManager;
        private readonly RoleManager<TurbinoRole> roleManager;

        public SampleDataSeeder(ITurbinoDbContext context, RoleManager<TurbinoRole> roleManager, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedRolesAsync(cancellationToken);
            await SeedManagersAsync(cancellationToken);
            await SeedDestinationsAsync(cancellationToken);
        }

        private async Task SeedDestinationsAsync(CancellationToken cancellationToken)
        {
            List<Destination> destinations = new List<Destination>()
            {
                new Destination()
                {
                    Name = "Costa Rica",
                    TimesVisited = 22,
                    Description = ApplicationConstants.DestinationDescription,
                    SpokenLanguage = "English",
                    Visa = "Not Required if You have European Passport",
                    Currency = "US Dollar, Euro.",
                    SquareArea = 32
                }
            };

            await context.Destinations.AddRangeAsync(destinations);
        }

        private async Task SeedManagersAsync(CancellationToken cancellationToken)
        {
            //var managers = new[]
            //{
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Ivan", LastName = "Ivanov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Petar", LastName = "Petrov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Sasho", LastName = "Trifonov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Lambi", LastName = "Kostov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
            //    new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Simeon", LastName = "Atanasov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow }
            //};
            //
            //context.Managers.AddRange(managers);
            await SeedRolesAndAdminAsync();
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRolesAsync(CancellationToken cancellationToken)
        {
            //var roles = new[]
            //{
            //    new TurbinoRole { Id = Guid.NewGuid().ToString(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
            //    new TurbinoRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" },
            //};
            //
            //context.TurbinoRoles.AddRange(roles);
            await context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedRolesAndAdminAsync()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new TurbinoRole("Admin"));
                await roleManager.CreateAsync(new TurbinoRole("User"));
            }

            if (!userManager.Users.Any())
            {
                TurbinoUser user = new TurbinoUser() { UserName = "admin", FirstName = "admin", LastName = "adminov" };
                await userManager.CreateAsync(user, "fr3s7ed23");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
