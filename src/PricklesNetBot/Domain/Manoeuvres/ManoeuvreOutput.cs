using PricklesNetBot.Domain.IO;

namespace PricklesNetBot.Domain.Manoeuvres
{
    public class ManoeuvreOutput
    {
        public OutputParameters OutputParameters { get; set; }

        public double EstimatedCompletionTime { get; set; }

        public ManoeuvreOutput(OutputParameters outputParameters, double estimatedCompletionTime)
        {
            OutputParameters = outputParameters;
            EstimatedCompletionTime = estimatedCompletionTime;
        }
    }
}
