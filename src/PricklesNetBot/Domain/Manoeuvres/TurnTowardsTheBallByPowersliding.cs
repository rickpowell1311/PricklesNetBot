using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class TurnTowardsTheBallByPowersliding : TurnTowardsTheBall
    {
        public override OutputParameters Execute(Player player, Ball ball)
        {
            var output = base.Execute(player, ball);
            output.TogglePowerslide(true);

            return output;
        }
    }
}
