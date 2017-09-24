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

        public OutputParameters Work(PlayerData playerData, BallData ballData)
        {
            if (!playerData.IsFacingTheBall(ballData))
            {
                if (!(currentManoeuvre is TurnTowardsTheBall))
                {
                    currentManoeuvre = new TurnTowardsTheBall();
                    currentManoeuvre.Start(playerData, ballData);
                }
            }
            else
            {
                if (!(currentManoeuvre is DriveStraight))
                {
                    currentManoeuvre = new DriveStraight();
                    currentManoeuvre.Start(playerData, ballData);
                }
            }

            return currentManoeuvre.Output;
        }
    }
}
