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
            currentManoeuvre = new TurnTowardsTheBall();
        }

        public OutputParameters Work(Player player, Ball ball)
        {
            if (currentManoeuvre is DodgeTowardsTheBall)
            {
                if (((DodgeTowardsTheBall)currentManoeuvre).IsComplete)
                {
                    currentManoeuvre = new TurnTowardsTheBall();
                }
            }
            else if (currentManoeuvre != new TurnTowardsTheBall())
            {
                if (player.IsNearToTheBall(ball))
                {
                    currentManoeuvre = new DodgeTowardsTheBall();
                }
                else
                {
                    currentManoeuvre = new TurnTowardsTheBall();
                }
            }
              
            return currentManoeuvre.Execute(player, ball);
        }
    }
}
