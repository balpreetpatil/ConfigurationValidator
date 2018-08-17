using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator
{
    public static class ValidationExtensions
    {
        public static IEnumerable<string> Validate(this object instance)
        {
            var context = new ValidationContext(instance, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(instance, context, results, true);

            return GetErrorMessages(results);
        }

        private static IEnumerable<string> GetErrorMessages(IEnumerable<ValidationResult> results)
        {
            foreach (var validationResult in results)
            {
                if (validationResult is CompositeValidationResult result)
                {
                    var errorMessages = GetErrorMessages(result.Results);
                    foreach (var errorMessage in errorMessages)
                    {
                        yield return errorMessage;
                    }
                }
                else
                {
                    yield return validationResult.ErrorMessage;
                }
            }
        }
    }
}
