using System.Collections.Generic;

namespace PricklesNetBot.Domain.IO
{
    public class OutputParameters
    {
        private readonly Turn turn;
        private readonly ForwardBackwardRotation fbRotation;
        private readonly Accelerate accelerate;
        private readonly bool jump;
        private readonly bool boost;
        private readonly bool powerslide;

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
                (int)turn,
                (int)fbRotation,
                accelerate.ForwardValue,
                accelerate.BackwardValue,
                jump ? 1 : 0,
                boost ? 1 : 0,
                powerslide ? 1 : 0
            }.ToArray();
        }

        public OutputParameters(Turn turn, ForwardBackwardRotation fbRotation, Accelerate accelerate, bool jump, bool boost, bool powerslide)
        {
            this.turn = turn;
            this.fbRotation = fbRotation;
            this.accelerate = accelerate;
            this.jump = jump;
            this.boost = boost;
            this.powerslide = powerslide;
        }
    }
}
