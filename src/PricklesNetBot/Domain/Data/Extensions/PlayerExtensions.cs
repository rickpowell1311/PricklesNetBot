using PricklesNetBot.Domain.Constants;
using PricklesNetBot.Domain.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PricklesNetBot.Domain.Data.Extensions
{
    public static class PlayerExtensions
    {
        public static bool IsNearToTheBall(this Player player, Ball ball)
        {
            var distanceApart = player.Position.Subtract(ball.Position)
                .TwoDimensionalLength;

            return Math.Abs(distanceApart) < BallConstants.Diameter * 2;
        }

        public static Turn TurnTowardsPosition(this Player player, Vector position)
        {
            var playerDirection = player.XYAngle.As2dVector(TwoDimensionalVectorType.XY);
            var playerToPositionDirection = position.Subtract(player.Position);

            var angleRelativeToPosition = playerDirection.TwoDimensionalShortestAngleBetween(playerToPositionDirection);
            var normalizedToleranceAngle = player.ToleranceAngleForTarget(position);

            if (angleRelativeToPosition.IsMoreThan(normalizedToleranceAngle))
            {
                bool turnRight = playerDirection.TwoDimensionalProduct(playerToPositionDirection) < 0;

                return turnRight ? Turn.FullRight : Turn.FullLeft;
            }

            return Turn.None;
        }

        public static Turn TurnTowardsPredictedBallPosition(this Player player, Ball ball)
        {
            /* Taken from http://jaran.de/goodbits/2011/07/17/calculating-an-intercept-course-to-a-target-with-constant-direction-and-velocity-in-a-2-dimensional-plane/
             * 
             * Vb = Velocity of the ball
             * Pb = Position of the ball
             * Vc = Velocity of the car
             * Pc = Position of the car
             * θ = Disired car direction
             * t = time
             * 
             * t = -h2/h1 +/- root((h2/h1)^2 - h3/h1)
             * 
             * where    h1 = Vbx^2 + Vby^2 - |Vc|^2,
             *          h2 = (Pbx - Pcx)Vbx + (Pbx - Pcy)Vby
             *          h3 = |Pbx - Pcx|^2 + |Pby - Pcy|^2
             *
             * Unless h1 = 0, in which case t = -h3/2h2
             */

            var h1 = Math.Round(Math.Pow(ball.Velocity.X, 2) + Math.Pow(ball.Velocity.Y, 2) - Math.Pow(ball.Velocity.TwoDimensionalLength, 2), 3);
            var h2 = Math.Round(ball.Velocity.X * (ball.Position.X - player.Position.X) + ball.Velocity.Y * (ball.Position.Y - player.Position.Y), 3);
            var h3 = Math.Round(Math.Pow(ball.Position.X - player.Position.X, 2) + Math.Pow(ball.Position.Y - player.Position.Y, 2), 3);

            double t = -1;
            if (h1 == 0)
            {
                t = -h3 / (2 * h2);
            }
            else
            {
                var t1 = -h2 + Math.Pow(Math.Pow(h2 / h1, 2) - h3 / h1, 0.5);
                var t2 = -h3 - Math.Pow(Math.Pow(h2 / h1, 2) - h3 / h1, 0.5);

                t = t1 > 0 ? t1 : t2;
            }

            var pointOfInterception = new Vector(ball.Position.X + t * ball.Velocity.X, ball.Position.Y + t * ball.Velocity.Y, 0);
            var targetVector = pointOfInterception.Subtract(player.Position);
            var targetAngle = player.XYAngle.As2dVector(TwoDimensionalVectorType.XY)
                .TwoDimensionalAngleBetween(targetVector);

            var toleranceAngle = player.ToleranceAngleForTarget(targetVector);

            if (targetAngle.IsMoreThan(toleranceAngle))
            {
                bool turnRight = targetAngle.Radians > Math.PI;

                return turnRight ? Turn.FullRight : Turn.FullLeft;
            }
            else
            {
                return Turn.None;
            }
        }

        public static Angle ToleranceAngleForTarget(this Player player, Vector target)
        {
            // Calculate tolerance based on width of the ball and how far away from the ball the car is;
            var distanceFromPosition = player.Position.Subtract(target).TwoDimensionalLength;
            var toleranceAngle = Angle.FromRadians(Math.Atan((BallConstants.Diameter / 2) / distanceFromPosition));

            var toleranceFactor = distanceFromPosition / GameplayConstants.BackOfGoalToBackOfGoalPitchLength
                * GameplayConstants.AngleToleranceFactorAtMaxDistanceFromPosition;

            return toleranceAngle.Multiply((1 + toleranceFactor));
        }

        public static bool IsFacingTheBall(this Player player, Ball ball)
        {
            var playerDirection = player.XYAngle.As2dVector(TwoDimensionalVectorType.XY);
            var playerToBallDirection = ball.Position.Subtract(player.Position);
            var angleRelativeToBall = playerDirection.TwoDimensionalShortestAngleBetween(playerToBallDirection);

            var distanceFromBall = player.Position.Subtract(ball.Position).TwoDimensionalLength;
            var toleranceAngle = Angle.FromRadians(Math.Atan((BallConstants.Diameter / 2) / distanceFromBall));

            return angleRelativeToBall.IsLessThan(toleranceAngle);
        }
    }
}
