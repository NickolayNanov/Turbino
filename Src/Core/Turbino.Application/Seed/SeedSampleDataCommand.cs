﻿namespace Turbino.Application.Seed
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common.Interfaces;
    using Turbino.Domain.Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ITurbinoDbContext context;

        public SeedSampleDataCommandHandler(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}