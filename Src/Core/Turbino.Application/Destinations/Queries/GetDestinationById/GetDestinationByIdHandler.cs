using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Exceptions;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;

namespace Turbino.Application.Destinations.Queries.GetDestinationById
{
    public class GetDestinationByIdHandler : IRequestHandler<GetDestinationByIdQuery, DestinationViewModel>
    {
        private readonly ITurbinoDbContext context;

        public GetDestinationByIdHandler(ITurbinoDbContext context)
        {
            this.context = context;
        }

        public async Task<DestinationViewModel> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            Destination destination = await context.Destinations.FindAsync(request.DestinationId);
            if(destination == null)
                throw new NotFoundException(nameof(Destination), request.DestinationId);
            destination.SetGalery(context.DestinationImages.AsNoTracking().Where(d => d.DestinationId == destination.Id).ToList());
            return DestinationViewModel.Create(destination);
        }
    }
}