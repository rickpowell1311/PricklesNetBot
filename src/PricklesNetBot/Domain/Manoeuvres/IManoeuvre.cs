using PricklesNetBot.Domain.Data;

namespace PricklesNetBot.Domain.Manoeuvre
{
    public interface IManoeuvre
    {
        int EstimateCompletionTime(PlayerData forPlayer, BallData ballData);

        void Execute(PlayerData forPlayer, BallData ballData);
    }
}
