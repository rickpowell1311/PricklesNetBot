using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Data
{
    public class Ball
    {
        private readonly InputParameters input;

        public double BallXPosition => input.BallXPosition;

        public double BallYPosition => input.BallYPosition;

        public double BallZPosition => input.BallZPosition;

        public double BallXVelocity => input.BallXVelocity;

        public double BallYVelocity => input.BallYVelocity;

        public double BallZVelocity => input.BallZVelocity;

        public Vector Position => new Vector(BallXPosition, BallYPosition, BallZPosition); 

        public Vector Velocity => new Vector(BallXVelocity, BallYVelocity, BallZVelocity);

        public Ball(InputParameters input)
        {
            this.input = input;
        }
    }
}
