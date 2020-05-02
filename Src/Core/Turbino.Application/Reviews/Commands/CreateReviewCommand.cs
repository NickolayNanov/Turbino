using MediatR;

namespace Turbino.Application.Reviews.Commands
{
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
