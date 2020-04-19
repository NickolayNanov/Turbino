﻿namespace Turbino.Application.Seed
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Interfaces;
    using Domain.Entities;
    using Domain.Enumerations;
    using Microsoft.AspNetCore.Identity;

    public class SampleDataSeeder
    {
        private readonly ITurbinoDbContext context;

        public SampleDataSeeder(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {           
           //if (context.TurbinoRoles.Any())
           //{
           //    return;
           //}
           //
           //await SeedRolesAsync(cancellationToken);
            await SeedManagersAsync(cancellationToken);
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
    }
}