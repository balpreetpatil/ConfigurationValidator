using System.ComponentModel.DataAnnotations;

namespace ConfigurationValidator.Tests
{
    public class LogConfiguration
    {
        [Required]
        public string FileLocation { get; set; }
        [Required]
        public string Level { get; set; }
    }
}