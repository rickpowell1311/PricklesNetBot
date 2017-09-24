using PricklesNetBot.Domain.Manoeuvres;
using System.Collections.Generic;
using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision.Tactical
{
    public class GoForTheBall : ITacticalDecision
    {
        private IManoeuvre currentManoeuvre;
        private Stack<IManoeuvre> manoeuvres;

        public bool Finished => currentManoeuvre == null && manoeuvres.Count == 0;

        public GoForTheBall()
        {
            manoeuvres = new Stack<IManoeuvre>();
            manoeuvres.Push(new TurnTowardsTheBall());
        }

        public OutputParameters Work(PlayerData playerData, BallData ballData)
        {
            if (currentManoeuvre != null)
            {
                if (currentManoeuvre.HasFinished(playerData, ballData))
                {
                    currentManoeuvre = null;
                }
                else
                {
                    return currentManoeuvre.Output;
                }
            }

            if (!Finished)
            {
                currentManoeuvre = manoeuvres.Pop();
                currentManoeuvre.Start(playerData, ballData);
                return currentManoeuvre.Output;
            }
            else
            {
                return OutputParameters.Default;
            }
        }
    }
}
