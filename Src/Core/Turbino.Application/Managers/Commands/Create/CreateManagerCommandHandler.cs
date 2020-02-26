namespace Turbino.Application.Managers.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Domain.Entities;
    using Domain.Enumerations;
    using Turbino.Application.Common.Interfaces;

    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMediator mediator;

        public CreateManagerCommandHandler(ITurbinoDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            //var manager = new Manager
            //{                
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    ReceptionDay = Enum.Parse<WeekDay>(request.ReceptionDay),
            //    CreatedOn = DateTime.UtcNow,
            //    IsDeleted = false
            //};
            //
            //this.context.Managers.Add(manager);
            //
            //await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
