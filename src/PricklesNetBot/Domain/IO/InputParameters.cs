using PricklesNetBot.Infrastructure;
using System;

namespace PricklesNetBot.Domain.IO
{
    public class InputParameters
    {
        private readonly double[] values;

        public double BallXPosition => values[0];
        public double BallYPosition => values[1];
        public double BallZPosition => values[2];

        public double BallXVelocity => values[3];
        public double BallYVelocity => values[4];
        public double BallZVelocity => values[5];

        public double Blue1XPosition => values[6];
        public double Blue1YPosition => values[7];
        public double Blue1ZPosition => values[8];

        public double Orange1XPosition => values[9];
        public double Orange1YPosition => values[10];
        public double Orange1ZPosition => values[11];

        public double Blue1XVelocity => values[12];
        public double Blue1YVelocity => values[13];
        public double Blue1ZVelocity => values[14];

        public double Orange1XVelocity => values[15];
        public double Orange1YVelocity => values[16];
        public double Orange1ZVelocity => values[17];

        public double Blue1Boost => values[18];
        public double Orange1Boost => values[19];

        public double Blue1Rotation1 => values[20];
        public double Blue1Rotation2 => values[21];
        public double Blue1Rotation3 => values[22];
        public double Blue1Rotation4 => values[23];
        public double Blue1Rotation5 => values[24];
        public double Blue1Rotation6 => values[25];
        public double Blue1Rotation7 => values[26];
        public double Blue1Rotation8 => values[27];
        public double Blue1Rotation9 => values[28];

        public double Orange1Rotation1 => values[29];
        public double Orange1Rotation2 => values[30];
        public double Orange1Rotation3 => values[31];
        public double Orange1Rotation4 => values[32];
        public double Orange1Rotation5 => values[33];
        public double Orange1Rotation6 => values[34];
        public double Orange1Rotation7 => values[35];
        public double Orange1Rotation8 => values[36];
        public double Orange1Rotation9 => values[37];

        public PlayerType CurrentPlayer => values[38] == 1 ? PlayerType.Blue1 : PlayerType.Orange1;

        public InputParameters(double[] values)
        {
            this.values = values;
        }
    }
}
