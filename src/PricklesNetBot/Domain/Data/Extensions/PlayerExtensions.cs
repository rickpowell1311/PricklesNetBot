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

            var targetTwoDimensionalAngle = player
                .XYAngle
                .As2dVector(TwoDimensionalVectorType.XY)
                .AngleBetween(player.DirectionToTheBall(ball));

            return targetTwoDimensionalAngle.IsLessThan(toleranceAngle);
        }

        public static Vector DirectionToTheBall(this Player player, Ball ball)
        {
            return ball.Position.Subtract(player.Position);
        }

        public static Angle AngleBetweenPlayerDirectionAndTheBall(this Player player, Ball ball)
        {
            var playerDirection = player
                .XYAngle
                .As2dVector(TwoDimensionalVectorType.XY);
            var playerToBallDirection = player.DirectionToTheBall(ball);
            return playerDirection.AngleBetween(playerToBallDirection);
        }
    }
}
