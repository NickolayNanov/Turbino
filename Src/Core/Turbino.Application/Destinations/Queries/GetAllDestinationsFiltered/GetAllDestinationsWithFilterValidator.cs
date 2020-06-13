namespace Turbino.Application.Destinations.Queries.GetAllDestinationsFiltered
{
    using FluentValidation;
    using Turbino.Common.GlobalContants;

    public class GetAllDestinationsWithFilterValidator : AbstractValidator<GetAllDestinationsWithFilterQuery>
    {
        public GetAllDestinationsWithFilterValidator()
        {
            RuleFor(x => x.DestinationName)
                .NotEmpty()
                .WithMessage(string.Format(ApplicationConstants.RequiredErrorMsg, nameof(GetAllDestinationsWithFilterQuery.DestinationName)));
        }
    }
}
