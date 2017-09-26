using PricklesNetBot.Domain.Constants;
using System;

namespace PricklesNetBot.Domain.Data.Extensions
{
    public static class PlayerExtensions
    {
        public static bool IsFacingTheBall(this Player player, Ball ball, double fractionalTolerance)
        {
            var toleranceOpposite = (BallConstants.Diameter / 2) * (1 + fractionalTolerance);
            var toleranceAdjacent = player.DirectionToTheBall(ball).TwoDimensionalLength;
            var toleranceAngle = Angle.FromRadians(Math.Atan(toleranceOpposite / toleranceAdjacent));

            var targetTwoDimensionalAngle =
                player.XYDirection().AngleBetween(player.DirectionToTheBall(ball));

            return targetTwoDimensionalAngle.IsLessThan(toleranceAngle);
        }

        public static Vector DirectionToTheBall(this Player player, Ball ball)
        {
            return ball.Position.Add(player.Position);
        }

        public static Vector XYDirection(this Player player)
        {
            return player.XYAngle.As2dVector(TwoDimensionalVectorType.XY);
        }

        public static Angle AngleBetweenPlayerDirectionAndTheBall(this Player player, Ball ball)
        {
            var playerDirection = player.XYDirection();
            var playerToBallDirection = player.DirectionToTheBall(ball);
            return playerDirection.AngleBetween(playerToBallDirection);
        }
    }
}
