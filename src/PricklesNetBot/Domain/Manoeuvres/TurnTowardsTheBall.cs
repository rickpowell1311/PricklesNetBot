using System;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Infrastructure;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        private OutputParameters output;

        public OutputParameters Output => output;

        public int EstimateCompletionTime(PlayerData forPlayer, BallData ballData)
        {
            throw new NotImplementedException();
        }

        public void Start(PlayerData playerData, BallData ballData)
        {
            var playerDirection = PlayerDirection(playerData);
            var playerToBallDirection = PlayerToBallDirection(playerData, ballData);
            var targetTwoDimensionalAngle = playerDirection.AngleBetween(playerToBallDirection);

            var turnDirection = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0
                ? Turn.Left
                : Turn.Right;

            output = new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                false);
        }

        public bool HasFinished(PlayerData playerData, BallData ballData)
        {
            var toleranceOpposite = BallData.Diameter / 2;
            var toleranceAdjacent = PlayerToBallDirection(playerData, ballData)
                .TwoDimensionalLength;

            var toleranceAngle = Math.Atan(toleranceOpposite / toleranceAdjacent).FromRadiansToDegrees();

            var targetTwoDimensionalAngle =
                PlayerDirection(playerData).AngleBetween(
                    PlayerToBallDirection(playerData, ballData));

            return targetTwoDimensionalAngle < toleranceAngle;
        }

        private Vector PlayerToBallDirection(PlayerData playerData, BallData ballData)
        {
            return new Vector(
                ballData.BallXPosition - playerData.XPosition,
                ballData.BallYPosition - playerData.YPosition,
                ballData.BallZPosition - playerData.ZPosition);
        }

        private Vector PlayerDirection(PlayerData playerData)
        {
            var yawRadians = playerData.Yaw.FromDegreesToRadians();

            var xLength = Math.Cos(yawRadians);
            var yLength = Math.Sin(yawRadians);

            return new Vector(xLength, yLength, 0);
        }
    }
}
