using System;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator.Tests
{
    public class ExampleConfiguration
    {
        [Required]
        public string ServiceName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Port number is missing.")]
        public int Port { get; set; }

        [Required, ValidateObject]
        public LogConfiguration LogConfiguration { get; set; }
    }
}
