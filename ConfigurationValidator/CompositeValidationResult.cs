using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator
{
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Results => _results;

        public CompositeValidationResult(string errorMessage)
            : base(errorMessage)
        {
        }

        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
}