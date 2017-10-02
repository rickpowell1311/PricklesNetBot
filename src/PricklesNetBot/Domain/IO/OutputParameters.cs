using System;
using System.Collections.Generic;

namespace PricklesNetBot.Domain.IO
{
    public class OutputParameters
    {
        public Turn Turn { get; private set; }
        public ForwardBackwardRotation FbRotation { get; private set; }
        public Accelerate Accelerate { get; private set; }
        public bool Jump { get; private set; }
        public bool Boost { get; private set; }
        public bool Powerslide { get; private set; }

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
                Turn.Value,
                FbRotation.Value,
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

        public void TogglePowerslide(bool isPowerslideOn)
        {
            this.Powerslide = isPowerslideOn;
        }

        public void ToggleBoost(bool isBoostEnabled)
        {
            Boost = isBoostEnabled;
        }
    }
}
