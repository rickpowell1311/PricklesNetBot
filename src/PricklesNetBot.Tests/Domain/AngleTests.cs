using PricklesNetBot.Domain;
using System;
using Xunit;

namespace PricklesNetBot.Tests.Domain
{
    public class AngleTests
    {
        [Theory]
        [InlineData(180)]
        [InlineData(540)]
        [InlineData(900)]
        [InlineData(-180)]
        public void Angle_CanConvertSimilarValuesToRadiansRepresentation(double input)
        {
            var result = Angle.FromDegrees(input);

            Assert.Equal(Math.Round(Math.PI, 3), Math.Round(result.Radians, 3));
        }

        [Theory]
        [InlineData(Math.PI)]
        [InlineData(3 * Math.PI)]
        [InlineData(5 * Math.PI)]
        [InlineData(-1 * Math.PI)]
        public void Angle_CanConvertSimilarValuesToDegreesRepresentation(double input)
        {
            var result = Angle.FromRadians(input);

            Assert.Equal(180, Math.Round(result.Degrees, 3));
        }
    }
}
