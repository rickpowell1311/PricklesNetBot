using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Decision.Tactical
{
    public interface ITacticalDecision
    {
        OutputParameters Work(PlayerData playerData, BallData ballData);
    }
}
