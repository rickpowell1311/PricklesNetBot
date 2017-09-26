using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using PricklesNetBot.Domain.Data.Extensions;
using PricklesNetBot.Domain.Manoeuvres;

namespace PricklesNetBot.Domain.Decision.Tactical
{
    public class GoForTheBall : ITacticalDecision
    {
        private IManoeuvre currentManoeuvre;

        public GoForTheBall()
        {
        }

        public OutputParameters Work(Player player, Ball ball)
        {
            if (currentManoeuvre is TurnTowardsTheBall)
            {
                if (player.IsFacingTheBall(ball, 0))
                {
                    currentManoeuvre = new DriveTowardsTheBall();
                }
            }
            else if (currentManoeuvre is DriveTowardsTheBall)
            {
                if (!player.IsFacingTheBall(ball, 100))
                {
                    currentManoeuvre = new TurnTowardsTheBall();
                }
            }

            return currentManoeuvre.Execute(player, ball);
        }
    }
}
