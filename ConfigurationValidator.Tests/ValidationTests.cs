using System;
using FluentAssertions;
using Xunit;

namespace ConfigurationValidator.Tests
{
    public class ValidationTests
    {
        private readonly ExampleConfiguration _configuration;

        public ValidationTests()
        {
            _configuration=new ExampleConfiguration
            {
                ServiceName = "HelloWorld",
                Port = 50001,
                LogConfiguration = new LogConfiguration
                {
                    FileLocation = @"c:\ApplicationLogs\HelloWorld",
                    Level = "INFO"
                }
            };
        }

        [Fact]
        public void Should_pass_validation()
        {
            var errors = _configuration.Validate();

            errors.Should().BeEmpty();
        }

        [Fact]
        public void Should_validate_complex_type()
        {
            _configuration.LogConfiguration.FileLocation=String.Empty;

            var errors = _configuration.Validate();

            errors.Should().ContainSingle();
        }
    }
}