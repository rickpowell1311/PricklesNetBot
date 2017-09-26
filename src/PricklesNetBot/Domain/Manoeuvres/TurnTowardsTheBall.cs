using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;
using PricklesNetBot.Domain.Constants;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        public ManoeuvreOutput Execute(Player player, Ball ball)
        {
            var playerDirection = player.XYDirection();
            var playerToBallDirection = player.DirectionToTheBall(ball);

            var powerslide = playerDirection.AngleBetween(playerToBallDirection).IsMoreThan(PowerslidingTowardsTheBall.WhenMoreThanAngle)
                && playerDirection.AngleBetween(playerToBallDirection).IsLessThan(PowerslidingTowardsTheBall.WhenMoreThanAngle.Invert());

            var turnDirection = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0
                ? Turn.Right
                : Turn.Left;

            var outputParams = new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                powerslide);

            var estimatedCompletionTime = 0; // TODO:

            return new ManoeuvreOutput(outputParams, estimatedCompletionTime);
        }
    }
}
