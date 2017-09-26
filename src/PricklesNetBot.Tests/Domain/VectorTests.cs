using PricklesNetBot.Domain;
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

            var result = alongXAxis.AngleBetween(vectorPointing315);

            Assert.Equal(315, result);
        }

        [Fact]
        public void AngleBetween_ReturnsAnglesSmallerThan180()
        {
            var alongXAxis = new Vector(1, 0, 0);
            var vectorPointing45 = new Vector(1, 1, 0);

            var result = alongXAxis.AngleBetween(vectorPointing45);

            Assert.Equal(45, result);
        }
    }
}
