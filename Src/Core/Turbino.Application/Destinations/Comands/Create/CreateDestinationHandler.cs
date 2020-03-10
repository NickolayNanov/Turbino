using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Common.Interfaces;
using Turbino.Domain.Entities;
using Turbino.Infrastructure;

namespace Turbino.Application.Destinations.Commands.Create
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly ImageUploader uploader;

        public CreateDestinationHandler(ITurbinoDbContext context, ImageUploader uploader)
        {
            this.context = context;
            this.uploader = uploader;
        }

        public async Task<Unit> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            Destination destination = new Destination()
            {
                Name = request.Name,
                Description = request.Description,
                SpokenLanguage = request.SpokenLanguage,
                Currency = request.Currency,
                Visa = request.Visa,
                SquareArea = request.SquareArea
            };

            destination.ImgUrl = uploader.UploadImage(request.ImgUrl, Guid.NewGuid().ToString());

            context.Destinations.Add(destination);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
