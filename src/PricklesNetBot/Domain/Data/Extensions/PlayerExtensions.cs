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
            /* We need to find a solution for the time it will take to reach the ball 
             * and the angle the car should travel at, given the ball position and velocity
             * 
             * Vb = Velocity of the ball
             * Pb = Position of the ball
             * Vc = Velocity of the car
             * Pc = Position of the car
             * θ = Disired car direction
             * t = time
             * 
             * Pc + tVc(sinθ + cosθ) = Pb + Vbt
             * Pc - Pb = Vbt - tVc(sinθ + cosθ)
             * Pc - Pb = t(Vb - Vc(sinθ + cosθ))
             * t = Pc - Pb / (Vb - Vc(sinθ + cosθ))
             * 
             * Try all 360 degrees angles and take the lowest possible positive t (if exists)
             * 
             */

            Func<Angle, double> solutionForTime = (Angle angle) =>
            {
                var sinPlusCosAngle = Math.Sin(angle.Radians) + Math.Sin(angle.Radians);

                return player.Position.Subtract(ball.Position).TwoDimensionalLength
                    / (ball.Velocity.Subtract(player.Velocity.ScalarMultiply(sinPlusCosAngle))).TwoDimensionalLength;
            };

            var solutions = new List<Tuple<Angle, double>>();
            for (int i = 0; i < 360; i++)
            {
                var angle = Angle.FromDegrees(i);
                var solution = solutionForTime(angle);

                if (solution > 0 && !double.IsInfinity(solution))
                {
                    solutions.Add(new Tuple<Angle, double>(angle, solution));
                }
            }

            var bestSolution = solutions
                .OrderBy(t => t.Item2)
                .FirstOrDefault();

            if (bestSolution != null)
            {
                var distanceFromTargetVector = bestSolution.Item1
                    .As2dVector(TwoDimensionalVectorType.XY)
                    .ScalarMultiply(bestSolution.Item2 * player.Velocity.TwoDimensionalLength);

                var toleranceAngle = player.ToleranceAngleForTarget(distanceFromTargetVector);

                var angle = bestSolution.Item1;

                if (angle.IsMoreThan(toleranceAngle))
                {
                    bool turnRight = angle.Radians > Math.PI;

                    return turnRight ? Turn.FullRight : Turn.FullLeft;
                }
                else
                {
                    return Turn.None;
                }
            }
            else
            {
                return player.TurnTowardsPosition(ball.Position);
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
