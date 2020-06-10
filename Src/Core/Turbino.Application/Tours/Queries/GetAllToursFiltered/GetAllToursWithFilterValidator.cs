using FluentValidation;
using System.Data;

namespace Turbino.Application.Tours.Queries.GetAllToursFiltered
{
    public class GetAllToursWithFilterValidator : AbstractValidator<GetAllToursWithFilterQuery>
    {
        public GetAllToursWithFilterValidator()
        {
        }
    }
}
