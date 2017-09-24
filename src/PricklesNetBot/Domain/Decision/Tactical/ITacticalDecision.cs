using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision.Tactical
{
    public interface ITacticalDecision
    {
        bool Finished { get; }

        OutputParameters Work(PlayerData playerData, BallData ballData);
    }
}
