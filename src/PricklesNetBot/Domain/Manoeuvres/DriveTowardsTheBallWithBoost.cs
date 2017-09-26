using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class DriveTowardsTheBallWithBoost : DriveTowardsTheBall
    {
        public override OutputParameters Execute(Player player, Ball ball)
        {
            var output = base.Execute(player, ball);
            output.ToggleBoost(true);

            return output;
        }
    }
}
