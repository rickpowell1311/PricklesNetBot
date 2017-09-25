using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DriveStraight : IManoeuvre
    {
        public OutputParameters Execute(PlayerData forPlayer, BallData ballData)
        {
            return new OutputParameters(
                Turn.None,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                true,
                false);
        }
    }
}
