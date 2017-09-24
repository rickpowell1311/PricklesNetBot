using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public interface IManoeuvre
    {
        OutputParameters Output { get; }

        int EstimateCompletionTime(PlayerData forPlayer, BallData ballData);

        void Start(PlayerData forPlayer, BallData ballData);

        bool HasFinished(PlayerData playerData, BallData ballData);
    }
}
