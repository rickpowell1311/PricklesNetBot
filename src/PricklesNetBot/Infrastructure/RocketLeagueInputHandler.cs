using Newtonsoft.Json;
using PricklesNetBot.Domain;
using PricklesNetBot.Domain.Decision;
using PricklesNetBot.Domain.IO;
using System.Collections.Generic;
using System.Text;

namespace PricklesNetBot.Infrastructure
{
    public class RocketLeagueHandler
    {
        private readonly Dictionary<PlayerType, Decider> deciders;

        public RocketLeagueHandler()
        {
            deciders = new Dictionary<PlayerType, Decider>();
            deciders.Add(PlayerType.Blue1, new Decider());
            deciders.Add(PlayerType.Orange1, new Decider());
        }

        public byte[] Handle(byte[] input)
        {
            var raw = Encoding.UTF8.GetString(input);
            var values = JsonConvert.DeserializeObject<double[]>(raw);
            var parameters = new InputParameters(values);

            var decider = deciders[parameters.CurrentPlayer];

            var output = decider.MakeMove(parameters);

            var outputRaw = JsonConvert.SerializeObject(output.AsResult());
            return Encoding.UTF8.GetBytes(outputRaw);
        }
    }
}
