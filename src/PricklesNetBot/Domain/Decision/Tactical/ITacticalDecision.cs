using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision.Tactical
{
    public interface ITacticalDecision
    {
        OutputParameters Work(Player player, Ball ball);
    }
}
