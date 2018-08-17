using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator
{
    public class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            Validator.TryValidateObject(value, context, results, true);

            if (results.Count == 0) return ValidationResult.Success;

            var compositeResults = new CompositeValidationResult(
                $"Validations for {validationContext.DisplayName} failed!");
            results.ForEach(x =>
            {
                x.ErrorMessage = validationContext.DisplayName + ": " + x.ErrorMessage;
                compositeResults.AddResult(x);
            });

            return compositeResults;
        }
    }
}