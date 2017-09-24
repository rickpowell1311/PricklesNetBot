using System;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DriveStraight : IManoeuvre
    {
        private OutputParameters output;

        public OutputParameters Output => output;

        public void Start(PlayerData forPlayer, BallData ballData)
        {
            output = new OutputParameters(
                Turn.None,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                true,
                false);
        }
    }
}
