using PricklesNetBot.Domain;
using System;
using Xunit;

namespace PricklesNetBot.Tests.Domain
{
    public class VectorTests
    {
        [Fact]
        public void AngleBetween_ReturnsAnglesBiggerThan180()
        {
            var alongXAxis = new Vector(1, 0, 0);
            var vectorPointing315 = new Vector(1, -1, 0);

            var result = alongXAxis.TwoDimensionalAngleBetween(vectorPointing315);

            Assert.Equal(315, Math.Round(result.Degrees, 3));
        }

        [Fact]
        public void AngleBetween_ReturnsAnglesSmallerThan180()
        {
            var alongXAxis = new Vector(1, 0, 0);
            var vectorPointing45 = new Vector(1, 1, 0);

            var result = alongXAxis.TwoDimensionalAngleBetween(vectorPointing45);

            Assert.Equal(45, Math.Round(result.Degrees, 3));
        }
    }
}
