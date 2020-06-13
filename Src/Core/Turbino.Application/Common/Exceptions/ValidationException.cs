namespace Turbino.Application.Common.Exceptions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using FluentValidation.Results;

    using Turbino.Common.GlobalContants;

    public class ValidationException : Exception
    {
        public ValidationException()
            : base(ApplicationConstants.BaseExceptionMessage)
        {
            this.Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            IEnumerable<string> propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                string[] propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                this.Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
