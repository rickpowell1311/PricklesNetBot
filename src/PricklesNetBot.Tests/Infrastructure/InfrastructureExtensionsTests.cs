using PricklesNetBot.Infrastructure;
using System;
using Xunit;

namespace PricklesNetBot.Tests.Infrastructure
{
    public class InfrastructureExtensionsTests
    {
        [Theory]
        [InlineData(180)]
        [InlineData(540)]
        [InlineData(900)]
        [InlineData(-180)]
        public void CanConvertSimilarValuesToOneRadiansRepresentation(double input)
        {
            var result = input.FromDegreesToRadians();

            Assert.Equal(Math.PI, result);
        }

        [Theory]
        [InlineData(Math.PI)]
        [InlineData(3 * Math.PI)]
        [InlineData(5 * Math.PI)]
        [InlineData(-1 * Math.PI)]
        public void CanConvertSimilarValuesToDegreesRepresentation(double input)
        {
            var result = input.FromRadiansToDegrees();

            Assert.Equal(180, result);
        }
    }
}
