using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DriveTowardsTheBall : IManoeuvre
    {
        public ManoeuvreOutput Execute(Player player, Ball ball)
        {
            var output = new OutputParameters(
                Turn.None,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                true,
                false);

            var estimatedCompletionTime = 0; // TODO:

            return new ManoeuvreOutput(output, estimatedCompletionTime);
        }
    }
}
