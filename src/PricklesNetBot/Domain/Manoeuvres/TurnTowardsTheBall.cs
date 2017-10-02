using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;
using PricklesNetBot.Domain.Constants;
using System;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBall : IManoeuvre
    {
        private bool hasFinished;

        public TurnTowardsTheBall()
        {
            this.hasFinished = false;
        }

        public virtual bool CheckIfFinished(Player player, Ball ball)
        {
            return this.hasFinished;
        }

        public virtual OutputParameters Execute(Player player, Ball ball)
        {
            var playerDirection = player.XYAngle.As2dVector(TwoDimensionalVectorType.XY);
            var playerToBallDirection = ball.Position.Subtract(player.Position);

            var turnDirection = player.TurnTowardsPredictedBallPosition(ball);

            var outputParams = new OutputParameters(
                turnDirection,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                turnDirection.Equals(Turn.None),
                false);

            return outputParams;
        }
    }
}
