using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;

namespace Turbino.Application.User.Commands.Create
{
    public class CreateTurbinoUserHandler : IRequestHandler<CreateTurbinoUserCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly IMediator mediator;

        public CreateTurbinoUserHandler(ITurbinoDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public Task<Unit> Handle(CreateTurbinoUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
