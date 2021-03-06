﻿namespace Turbino.Application.Destinations.Commands.Create
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Turbino.Infrastructure;
    using Turbino.Domain.Entities;
    using Turbino.Application.Common.Interfaces;

    using MediatR;
    using FluentValidation;
    using FluentValidation.Results;

    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, string[]>
    {
        private readonly ITurbinoDbContext context;
        private readonly IValidator<CreateDestinationCommand> validator;
        private readonly ImageUploader uploader;

        public CreateDestinationHandler(ITurbinoDbContext context, IValidator<CreateDestinationCommand> validator, ImageUploader uploader)
        {
            this.context = context;
            this.validator = validator;
            this.uploader = uploader;
        }

        public async Task<string[]> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                return validation.Errors.Select(x => x.ErrorMessage).ToArray();
            }

            string[] imgUrls = new string[]
            {
                uploader.UploadImage(request.FirstImg, Guid.NewGuid().ToString()),
                uploader.UploadImage(request.SecondImg, Guid.NewGuid().ToString()),
                uploader.UploadImage(request.ImgUrl, Guid.NewGuid().ToString())
            };

            Destination destination = new Destination()
            {
                Name = request.Name,
                Description = CreateDescription(request, imgUrls),
                SpokenLanguage = request.SpokenLanguage,
                Currency = request.Currency,
                Visa = request.Visa,
                SquareArea = request.SquareArea.Value,
                ImgUrl = imgUrls[2]
            };

            destination.ImgUrl = uploader.UploadImage(request.ImgUrl, Guid.NewGuid().ToString());
            string destinationId = context.Destinations.Add(destination).Entity.Id;

            for (int i = 0; i < imgUrls.Length - 1; i++)
            {
                context.DestinationImages.Add(new DestinationImage(destinationId, imgUrls[i]));
            }

            await context.SaveChangesAsync(cancellationToken);
            return new string[0];
        }

        private string CreateDescription(CreateDestinationCommand request, string[] imgUrls)
        {
            return $"<div class=\"mr-lg-5\"><div class=\"tour-schedule\"><h6 class=\"black bold mt-5 mb-3\">{request.DestinationNameHeader}</h6><p>{request.DestinationNameParagraph}</p><div class=\"list-font semibold mt-3\">{request.DestinationFirstHeader}</div><p>{request.DestinationFirstParagraph}</p><div class=\"list-font semibold mt-3\">{request.DestinationSecondHeader}</div><p>{request.DestinationSecondParagraph}</p><img class=\"img-fluid my-3\" src=\"{imgUrls[0]}\" alt=\"\"><h6 class=\"black bold mt-5 mb-3\">{request.DestinationThirdHeader}</h6><p>{request.DestinationThirdParagraph}</p><div class=\"list-font semibold mt-3\">{request.DestinationForthHeader}</div><p>{request.DestinationThirdParagraph}</p><img class=\"img-fluid my-3\" src=\"{imgUrls[1]}\" alt=\"image\"><div class=\"list-font semibold mt-3\">{request.DestinationFifthHeader}</div><p class=\"mb-0\">{request.DestinationFifthParagraph}</p></div></div>";
        }
    }
}
