using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public interface IManoeuvre
    {
        OutputParameters Output { get; }

        void Start(PlayerData forPlayer, BallData ballData);
    }
}
