using PricklesNetBot.Domain;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Manoeuvres;
using PricklesNetBot.Tests.Builders;
using System;
using Xunit;

namespace PricklesNetBot.Tests.Domain.Manoeuvres
{
    public class TurnTowardsTheBallTests
    {
        [Fact]
        public void WhenPlayerIsFacingToTheRightOfTheBall_TurnTowardsTheBall_TurnsLeft()
        {
            var inputBuilder = new InputParametersBuilder();
            inputBuilder.SetBallPosition(new Vector(0, 0, 0));

            // Car is facing 45 degrees to the right of the ball
            inputBuilder.SetCurrentPlayer(PlayerType.Blue1);
            inputBuilder.SetPlayerPosition(PlayerType.Blue1, new Vector(50, 0, 0));
            inputBuilder.SetPlayerRotation(PlayerType.Blue1, 1, 0, 0, 1, 0, 0, 0, 0, 0);

            var input = inputBuilder.Build();

            var result = new TurnTowardsTheBall()
                .Execute(new PlayerData(input), new BallData(input));

            Assert.Equal(Turn.Left, result.Turn);
        }

        [Fact]
        public void WhenPlayerIsFacingToTheLeftOfTheBall_TurnTowardsTheBall_TurnsRight()
        {
            var inputBuilder = new InputParametersBuilder();
            inputBuilder.SetBallPosition(new Vector(0, 0, 0));

            // Car is facing 45 degrees to the left of the ball
            inputBuilder.SetCurrentPlayer(PlayerType.Blue1);
            inputBuilder.SetPlayerPosition(PlayerType.Blue1, new Vector(50, 0, 0));
            inputBuilder.SetPlayerRotation(PlayerType.Blue1, -1, 0, 0, -1, 0, 0, 0, 0, 0);

            var input = inputBuilder.Build();

            var result = new TurnTowardsTheBall()
                .Execute(new PlayerData(input), new BallData(input));

            Assert.Equal(Turn.Right, result.Turn);
        }
    }
}
