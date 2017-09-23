using Newtonsoft.Json;
using PricklesNetBot.Domain.Decision;
using PricklesNetBot.Domain.IO;
using System;
using System.Text;

namespace PricklesNetBot.Infrastructure
{
    public class RocketLeagueHandler
    {
        private readonly Decider decider;

        public RocketLeagueHandler(Decider decider)
        {
            this.decider = decider;
        }

        public byte[] Handle(byte[] input)
        {
            var raw = Encoding.UTF8.GetString(input);
            var values = JsonConvert.DeserializeObject<double[]>(raw);
            var parameters = new InputParameters(values);

            var output = decider.MakeMove(parameters);
            var outputRaw = JsonConvert.SerializeObject(output.AsResult());
            return Encoding.UTF8.GetBytes(outputRaw);
        }
    }
}
