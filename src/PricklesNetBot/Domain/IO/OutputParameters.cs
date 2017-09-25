using System.Collections.Generic;

namespace PricklesNetBot.Domain.IO
{
    public class OutputParameters
    {
        public Turn Turn { get; }
        public ForwardBackwardRotation FbRotation { get; }
        public Accelerate Accelerate { get; }
        public bool Jump { get; }
        public bool Boost { get; }
        public bool Powerslide { get; }

        public static OutputParameters Default
        {
            get
            {
                return new OutputParameters(
                    Turn.None,
                    ForwardBackwardRotation.None,
                    Accelerate.None,
                    false,
                    false,
                    false);
            }
        }

        public int[] AsResult()
        {
            return new List<int>
            {
                (int)Turn,
                (int)FbRotation,
                Accelerate.ForwardValue,
                Accelerate.BackwardValue,
                Jump ? 1 : 0,
                Boost ? 1 : 0,
                Powerslide ? 1 : 0
            }.ToArray();
        }

        public OutputParameters(Turn turn, ForwardBackwardRotation fbRotation, Accelerate accelerate, bool jump, bool boost, bool powerslide)
        {
            this.Turn = turn;
            this.FbRotation = fbRotation;
            this.Accelerate = accelerate;
            this.Jump = jump;
            this.Boost = boost;
            this.Powerslide = powerslide;
        }
    }
}
