using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.CrossCutting
{
    public static class ValidationExtensions
    {
        public static string[] ToErrors(this IList<ValidationFailure> validationFailures)
            => validationFailures.Select(x => x.ErrorMessage)
                                 .ToArray();
    }
}
