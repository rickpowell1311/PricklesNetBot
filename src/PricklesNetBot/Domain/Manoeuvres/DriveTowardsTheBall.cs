using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DriveTowardsTheBall : IManoeuvre
    {
        public virtual OutputParameters Execute(Player player, Ball ball)
        {
            var output = new OutputParameters(
                Turn.None,
                ForwardBackwardRotation.None,
                Accelerate.Forward,
                false,
                false,
                false);

            return output;
        }
    }
}
