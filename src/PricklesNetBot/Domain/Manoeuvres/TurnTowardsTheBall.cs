using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        public virtual OutputParameters Execute(Player player, Ball ball)
        {
            var playerDirection = player.XYDirection();
            var playerToBallDirection = player.DirectionToTheBall(ball);

            var turnDirection = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0
                ? Turn.Right
                : Turn.Left;

            var outputParams = new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                false);

            return outputParams;
        }
    }
}
