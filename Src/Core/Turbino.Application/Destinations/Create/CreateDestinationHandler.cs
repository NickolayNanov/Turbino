using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Create
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, Unit>
    {
        private readonly ITurbinoDbContext context;

        public CreateDestinationHandler(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            Destination destination = new Destination()
            {
                Name = request.Name,
                Description = request.Description,
                SpokenLanguage = request.SpokenLanguage,
                Currency = request.Currency,
                Visa = request.Visa
            };

            context.Destinations.Add(destination);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
