using FluentValidation;

namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    public class GetAllDestinationsWithFilterValidator : AbstractValidator<GetAllDestinationsWithFilterQuery>
    {
        public GetAllDestinationsWithFilterValidator()
        {
            RuleFor(x => x.DestinationName)
                .NotEmpty()
                .WithMessage("The name of the destination cannot be empty!");
        }
    }
}
