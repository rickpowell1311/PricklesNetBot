using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.Decision.Tactical;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision
{
    public class Decider
    {
        private ITacticalDecision currentDecision;

        public Decider()
        {
            currentDecision = new GoForTheBall();
        }

        public OutputParameters MakeMove(InputParameters input)
        {
            // TODO: Make current decision

            if (!currentDecision.Finished)
            {
                return currentDecision.Work(
                new PlayerData(input),
                new BallData(input));
            }
            else
            {
                currentDecision = new GoForTheBall();
                return currentDecision.Work(
                    new PlayerData(input),
                    new BallData(input));
            }
        }
    }
}
