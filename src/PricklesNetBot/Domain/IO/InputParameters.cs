using PricklesNetBot.Infrastructure;
using System;

namespace PricklesNetBot.Domain.IO
{
    public class InputParameters
    {
        private readonly double[] values;

        public double BallXPosition => values[1];
        public double BallYPosition => values[0];
        public double BallZPosition => values[2];

        public double BallXVelocity => values[3];
        public double BallYVelocity => values[5];
        public double BallZVelocity => values[4];

        public double Blue1XPosition => values[7];
        public double Blue1YPosition => values[6];
        public double Blue1ZPosition => values[8];

        public double Orange1XPosition => values[10];
        public double Orange1YPosition => values[9];
        public double Orange1ZPosition => values[11];

        public double Blue1XVelocity => values[12];
        public double Blue1YVelocity => values[14];
        public double Blue1ZVelocity => values[13];

        public double Orange1XVelocity => values[15];
        public double Orange1YVelocity => values[16];
        public double Orange1ZVelocity => values[17];

        public double Blue1Boost => values[18];
        public double Orange1Boost => values[19];

        public double Blue1Roll => values[20].FromRadiansToDegrees();
        public double Blue1Pitch => values[21].FromRadiansToDegrees();
        public double Blue1Yaw => values[22].FromRadiansToDegrees();

        public double Orange1Roll => values[23].FromRadiansToDegrees();
        public double Orange1Pitch => values[24].FromRadiansToDegrees();
        public double Orange1Yaw => values[25].FromRadiansToDegrees();

        public PlayerType CurrentPlayer => values[26] == 1 ? PlayerType.Blue1 : PlayerType.Orange1;

        public InputParameters(double[] values)
        {
            this.values = values;
        }
    }
}
