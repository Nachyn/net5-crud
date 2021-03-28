using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using TomskEdaRu.Logic.Common.Exceptions.Base;

namespace TomskEdaRu.Logic.Common.Exceptions.Api
{
    public class BadRequestException : BaseException
    {
        public BadRequestException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public BadRequestException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            var failureGroups = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public BadRequestException(params string[] errors)
            : this()
        {
            if (errors != null)
            {
                Failures.Add(string.Empty, errors);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}