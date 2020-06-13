namespace Turbino.Application.Reviews.Commands
{
    using MediatR;

    public class CreateReviewCommand : IRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Rating { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string TourId { get; set; }
    }
}
