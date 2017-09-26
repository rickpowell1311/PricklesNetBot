using PricklesNetBot.Infrastructure;
using System;

namespace PricklesNetBot.Domain.Data.Extensions
{
    public static class PlayerDataExtensions
    {
        public static bool IsFacingTheBall(this PlayerData player, BallData ball)
        {
            var toleranceOpposite = BallData.Diameter / 2;
            var toleranceAdjacent = player.DirectionToTheBall(ball).TwoDimensionalLength;
            var toleranceAngle = Math.Atan(toleranceOpposite / toleranceAdjacent).FromRadiansToDegrees();

            var targetTwoDimensionalAngle =
                player.Direction().AngleBetween(player.DirectionToTheBall(ball));

            return targetTwoDimensionalAngle < toleranceAngle;
        }

        public static Vector DirectionToTheBall(this PlayerData player, BallData ball)
        {
            return new Vector(
                ball.BallXPosition - player.XPosition,
                ball.BallYPosition - player.YPosition,
                ball.BallZPosition - player.ZPosition);
        }

        public static Vector Direction(this PlayerData player)
        {
            var yawRadians = player.XYAngle.FromDegreesToRadians();

            var xLength = Math.Cos(yawRadians);
            var yLength = Math.Sin(yawRadians);

            return new Vector(xLength, yLength, 0);
        }

        public static double AngleBetweenPlayerDirectionAndTheBall(this PlayerData player, BallData ball)
        {
            var playerDirection = player.Direction();
            var playerToBallDirection = player.DirectionToTheBall(ball);
            return playerDirection.AngleBetween(playerToBallDirection);
        }
    }
}
