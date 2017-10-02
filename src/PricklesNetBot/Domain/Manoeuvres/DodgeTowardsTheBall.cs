using System;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Constants;
using PricklesNetBot.Domain.Data.Extensions;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DodgeTowardsTheBall : IManoeuvre
    {
        private DateTime? firstJumpCompleteAt;
        public bool IsComplete { get; private set; }

        public DodgeTowardsTheBall()
        {
            IsComplete = false;
        }

        public virtual OutputParameters Execute(Player player, Ball ball)
        {
            if (!firstJumpCompleteAt.HasValue)
            {
                firstJumpCompleteAt = DateTime.Now;

                return new OutputParameters(
                    Turn.None,
                    ForwardBackwardRotation.FullForward,
                    Accelerate.None,
                    true,
                    false,
                    false);
            }
            else if (!IsComplete 
                && DateTime.Now.Subtract(firstJumpCompleteAt.Value).TotalMilliseconds > PlayerMovement.SecondFlipDelay)
            {
                IsComplete = true;

                var playerDirection = player.XYAngle.As2dVector(TwoDimensionalVectorType.XY);
                var playerToBallDirection = ball.Position.Subtract(player.Position);
                var angleBetweenPlayerAndBall = playerDirection
                    .TwoDimensionalShortestAngleBetween(playerToBallDirection);

                var shouldTurnRight = playerDirection.TwoDimensionalProduct(playerToBallDirection) < 0;

                if (player.IsFacingTheBall(ball))
                {
                    return new OutputParameters(
                        Turn.None,
                        ForwardBackwardRotation.FullForward,
                        Accelerate.Forward,
                        true,
                        false,
                        false);
                }
                else
                {
                    return new OutputParameters(
                        shouldTurnRight ? Turn.FullRight : Turn.FullLeft,
                        ForwardBackwardRotation.None,
                        Accelerate.Forward,
                        true,
                        false,
                        false);
                }
            }

            return OutputParameters.Default;
        }
    }
}
