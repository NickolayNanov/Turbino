namespace Turbino.Application.Reviews.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Application.Common.Interfaces;
    using Turbino.Domain.Entities;
    using Turbino.Domain.Enumerations;

    using MediatR;

    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Unit>
    {
        private readonly ITurbinoDbContext context;
        private readonly UserManager<TurbinoUser> userManager;

        public CreateReviewHandler(ITurbinoDbContext context, UserManager<TurbinoUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            TurbinoUser author = await userManager.FindByNameAsync(request.AuthorName);

            Review review = new Review()
            {
                ReviewerName = request.AuthorName,
                ReviewerEmail = request.Email,
                Rating = Enum.Parse<Rating>(request.Rating),
                Content = request.Content,
                TourId = request.TourId,
                AuthorId = author.Id,
                CreatedOn = DateTime.Now
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
