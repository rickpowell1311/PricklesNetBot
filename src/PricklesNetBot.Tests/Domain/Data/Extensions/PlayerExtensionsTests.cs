using PricklesNetBot.Domain;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.Data.Extensions;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PricklesNetBot.Tests.Domain.Data.Extensions
{
    public class PlayerExtensionsTests
    {
        [Fact]
        public void WhenPlayerIsFacingToTheRightOfPosition_TurnTowardsTheBall_TurnsLeft()
        {
            var inputBuilder = new InputParametersBuilder();

            inputBuilder.SetCurrentPlayer(PlayerType.Blue1);
            inputBuilder.SetPlayerPosition(PlayerType.Blue1, new Vector(50, 0, 0));
            inputBuilder.SetPlayerRotation(PlayerType.Blue1, 1, 0, 0, 0.5, 0, 0, 0, 0, 0);

            var input = inputBuilder.Build();

            var player = new Player(input);
            var result = player.TurnTowardsPosition(new Vector(0, 0, 0));

            Assert.Equal(Turn.FullLeft.Value, result.Value);
        }

        [Fact]
        public void WhenPlayerIsFacingToTheLeftOfTheBall_TurnTowardsTheBall_TurnsRight()
        {
            var inputBuilder = new InputParametersBuilder();

            inputBuilder.SetCurrentPlayer(PlayerType.Blue1);
            inputBuilder.SetPlayerPosition(PlayerType.Blue1, new Vector(50, 0, 0));
            inputBuilder.SetPlayerRotation(PlayerType.Blue1, -1, 0, 0, -0.5, 0, 0, 0, 0, 0);

            var input = inputBuilder.Build();
            var player = new Player(input);

            var result = player.TurnTowardsPosition(new Vector(0, 0, 0));

            Assert.Equal(Turn.FullRight.Value, result.Value);
        }

        [Fact]
        public void WhenPlayerAndTargetPositionsAndVelocitiesAreMirroredOnTheYAxis_TurnTowardsPredictedBallPosition_TurnsNone()
        {
            var inputBuilder = new InputParametersBuilder();

            inputBuilder.SetCurrentPlayer(PlayerType.Blue1);

            inputBuilder.SetPlayerPosition(PlayerType.Blue1, new Vector(50, 0, 0));
            inputBuilder.SetPlayerRotation(PlayerType.Blue1, 1, 0, 0, -1, 0, 0, 0, 0, 0);
            inputBuilder.SetPlayerVelocity(PlayerType.Blue1, new Vector(-1, 1, 0));

            inputBuilder.SetBallPosition(new Vector(-50, 0, 0));
            inputBuilder.SetBallVelocity(new Vector(1, 1, 0));

            var input = inputBuilder.Build();
            var player = new Player(input);
            var ball = new Ball(input);

            var result = player.TurnTowardsPredictedBallPosition(ball);

            Assert.Equal(Turn.None.Value, result.Value);
        }
    }
}
