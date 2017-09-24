using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Data
{
    public class BallData
    {
        private readonly InputParameters input;

        public const double Diameter = 5;

        public double BallXPosition => input.BallXPosition;

        public double BallYPosition => input.BallYPosition;

        public double BallZPosition => input.BallZPosition;

        public double BallXVelocity => input.BallXVelocity;

        public double BallYVelocity => input.BallYVelocity;

        public double BallZVelocity => input.BallZVelocity;

        public BallData(InputParameters input)
        {
            this.input = input;
        }
    }
}
