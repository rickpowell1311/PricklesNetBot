using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        public OutputParameters Execute(PlayerData playerData, BallData ballData)
        {
            var playerDirection = playerData.Direction();
            var playerToBallDirection = playerData.DirectionToTheBall(ballData);

            var turnDirection = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0
                ? Turn.Right
                : Turn.Left;

            return new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                false);
        }
    }
}
