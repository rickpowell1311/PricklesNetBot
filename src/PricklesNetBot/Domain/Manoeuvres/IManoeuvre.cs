using PricklesNetBot.Domain.Data;
using PricklesNetBot.Domain.IO;
using System;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public interface IManoeuvre
    {
        ManoeuvreOutput Execute(Player forPlayer, Ball ballData);
    }
}
