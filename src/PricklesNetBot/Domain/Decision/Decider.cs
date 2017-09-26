using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.Decision.Tactical;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision
{
    public class Decider
    {
        private ITacticalDecision decision;

        public Decider()
        {
            decision = new GoForTheBall();
        }

        public OutputParameters MakeMove(InputParameters input)
        {
            // TODO: Make current decision
            return decision.Work(
                    new Player(input),
                    new Ball(input));
        }
    }
}
