using System;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        private OutputParameters output;

        public OutputParameters Output => output;

        public void Start(PlayerData playerData, BallData ballData)
        {
            var playerDirection = playerData.DirectionToTheBall(ballData);
            var playerToBallDirection = playerData.DirectionToTheBall(ballData);

            var turnDirection = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0
                ? Turn.Right
                : Turn.Left;

            output = new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                false);
        }
    }
}
