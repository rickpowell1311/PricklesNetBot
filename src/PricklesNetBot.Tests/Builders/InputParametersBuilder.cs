using PricklesNetBot.Domain;
using PricklesNetBot.Domain.IO;
using System;

namespace PricklesNetBot.Tests.Builders
{
    public class InputParametersBuilder
    {
        private double ballXPosition;
        private double ballYPosition;
        private double ballZPosition;

        private double ballXVelocity;
        private double ballYVelocity;
        private double ballZVelocity;

        private double blue1XPosition;
        private double blue1YPosition;
        private double blue1ZPosition;

        private double orange1XPosition;
        private double orange1YPosition;
        private double orange1ZPosition;

        private double blue1XVelocity;
        private double blue1YVelocity;
        private double blue1ZVelocity;

        private double orange1XVelocity;
        private double orange1YVelocity;
        private double orange1ZVelocity;

        private double blue1Boost;
        private double orange1Boost;

        private double blue1Roll;
        private double blue1Pitch;
        private double blue1Yaw;

        private double orange1Roll;
        private double orange1Pitch;
        private double orange1Yaw;

        private double currentPlayer;

        public InputParameters Build()
        {
            return new InputParameters(new[]
            {
                ballYPosition,
                ballXPosition,
                ballZPosition,
                ballXVelocity,
                ballZVelocity,
                ballYVelocity,
                blue1YPosition,
                blue1XPosition,
                blue1ZPosition,
                orange1YPosition,
                orange1XPosition,
                orange1ZPosition,
                blue1XVelocity,
                blue1ZVelocity,
                blue1YVelocity,
                orange1XVelocity,
                orange1YVelocity,
                orange1ZVelocity,
                blue1Boost,
                orange1Boost,
                blue1Roll,
                blue1Pitch,
                blue1Yaw,
                orange1Roll,
                orange1Pitch,
                orange1Yaw,
                currentPlayer
            });
        }

        /*
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

        public PlayerType CurrentPlayer => values[26]
        */

        public void SetCurrentPlayer(PlayerType player)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    currentPlayer = 1;
                    break;
                case PlayerType.Orange1:
                    currentPlayer = 2;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void SetBallPosition(Vector vector)
        {
            ballXPosition = vector.X;
            ballYPosition = vector.Y;
            ballZPosition = vector.Z;
        }

        public void SetBallVelocity(Vector vector)
        {
            ballXVelocity = vector.X;
            ballYVelocity = vector.Y;
            ballZVelocity = vector.Z;
        }

        public void SetPlayerPosition(PlayerType player, Vector vector)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    blue1XPosition = vector.X;
                    blue1YPosition = vector.Y;
                    blue1ZPosition = vector.Z;
                    break;
                case PlayerType.Orange1:
                    orange1XPosition = vector.X;
                    orange1YPosition = vector.Y;
                    orange1ZPosition = vector.Z;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void SetPlayerVelocity(PlayerType player, Vector vector)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    blue1XVelocity = vector.X;
                    blue1YVelocity = vector.Y;
                    blue1ZVelocity = vector.Z;
                    break;
                case PlayerType.Orange1:
                    orange1XVelocity = vector.X;
                    orange1YVelocity = vector.Y;
                    orange1ZVelocity = vector.Z;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void SetPlayerRotation(PlayerType player, double yawInRadians, double pitchInRadians, double rollInRadians)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    blue1Yaw = yawInRadians;
                    blue1Pitch = pitchInRadians;
                    blue1Roll = rollInRadians;
                    break;
                case PlayerType.Orange1:
                    orange1Yaw = yawInRadians;
                    orange1Pitch = pitchInRadians;
                    orange1Roll = rollInRadians;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void SetPlayerBoost(PlayerType player, double boost)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    blue1Boost = boost;
                    break;
                case PlayerType.Orange1:
                    orange1Boost = boost;
                    break;
            }
        }
    }
}
