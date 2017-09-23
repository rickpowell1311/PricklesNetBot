using PricklesNetBot.Domain.Data;

namespace PricklesNetBot.Domain.Manouvre
{
    public interface IManouvre
    {
        int EstimateCompletionTime(PlayerData forPlayer, BallData ballData);

        void Execute(PlayerData forPlayer, BallData ballData);
    }
}
