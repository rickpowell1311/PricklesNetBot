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

        private double blue1rotation1;
        private double blue1rotation2;
        private double blue1rotation3;
        private double blue1rotation4;
        private double blue1rotation5;
        private double blue1rotation6;
        private double blue1rotation7;
        private double blue1rotation8;
        private double blue1rotation9;

        private double orange1rotation1;
        private double orange1rotation2;
        private double orange1rotation3;
        private double orange1rotation4;
        private double orange1rotation5;
        private double orange1rotation6;
        private double orange1rotation7;
        private double orange1rotation8;
        private double orange1rotation9;

        private double currentPlayer;

        public InputParameters Build()
        {
            return new InputParameters(new[]
            {
                ballXPosition,
                ballYPosition,
                ballZPosition,
                ballXVelocity,
                ballYVelocity,
                ballZVelocity,
                blue1XPosition,
                blue1YPosition,
                blue1ZPosition,
                orange1XPosition,
                orange1YPosition,
                orange1ZPosition,
                blue1XVelocity,
                blue1YVelocity,
                blue1ZVelocity,
                orange1XVelocity,
                orange1YVelocity,
                orange1ZVelocity,
                blue1Boost,
                orange1Boost,
                blue1rotation1,
                blue1rotation2,
                blue1rotation3,
                blue1rotation4,
                blue1rotation5,
                blue1rotation6,
                blue1rotation7,
                blue1rotation8,
                blue1rotation9,
                orange1rotation1,
                orange1rotation2,
                orange1rotation3,
                orange1rotation4,
                orange1rotation5,
                orange1rotation6,
                orange1rotation7,
                orange1rotation8,
                orange1rotation9,
                currentPlayer
            });
        }

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

        public void SetPlayerRotation(
            PlayerType player, 
            double rotation1,
            double rotation2,
            double rotation3,
            double rotation4,
            double rotation5,
            double rotation6,
            double rotation7,
            double rotation8,
            double rotation9)
        {
            switch (player)
            {
                case PlayerType.Blue1:
                    blue1rotation1 = rotation1;
                    blue1rotation2 = rotation2;
                    blue1rotation3 = rotation3;
                    blue1rotation4 = rotation4;
                    blue1rotation5 = rotation5;
                    blue1rotation6 = rotation6;
                    blue1rotation7 = rotation7;
                    blue1rotation8 = rotation8;
                    blue1rotation9 = rotation9;
                    break;
                case PlayerType.Orange1:
                    orange1rotation1 = rotation1;
                    orange1rotation2 = rotation2;
                    orange1rotation3 = rotation3;
                    orange1rotation4 = rotation4;
                    orange1rotation5 = rotation5;
                    orange1rotation6 = rotation6;
                    orange1rotation7 = rotation7;
                    orange1rotation8 = rotation8;
                    orange1rotation9 = rotation9;
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
