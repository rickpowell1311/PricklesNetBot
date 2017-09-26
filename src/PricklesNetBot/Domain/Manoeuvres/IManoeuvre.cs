using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public interface IManoeuvre
    {
        OutputParameters Execute(Player forPlayer, Ball ballData);
    }
}
