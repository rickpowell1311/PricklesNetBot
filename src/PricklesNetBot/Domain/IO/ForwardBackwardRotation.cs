using PricklesNetBot.Domain.Constants;
using System;

namespace PricklesNetBot.Domain.IO
{
    public class ForwardBackwardRotation
    {
        public int Value { get; private set; }

        public static ForwardBackwardRotation FullForward
        {
            get
            {
                return new ForwardBackwardRotation(0);
            }
        }

        public static ForwardBackwardRotation FullBackward
        {
            get
            {
                return new ForwardBackwardRotation(32767);
            }
        }

        public static ForwardBackwardRotation None
        {
            get
            {
                return new ForwardBackwardRotation(16383);
            }
        }

        public ForwardBackwardRotation(int value)
        {
            if (PlayerMovement.LowerAxisDeadzone < value && value < PlayerMovement.UpperAxisDeadzone)
            {
                Value = 16383;
            }
            else
            {
                Value = value;
            }
        }

        public static ForwardBackwardRotation CustomFractionForward(double fraction)
        {
            var roundedValue = (int)Math.Round(fraction * 16383, 0);
            return new ForwardBackwardRotation(roundedValue);
        }

        public static ForwardBackwardRotation CustomFractionBackward(double fraction)
        {
            var roundedValue = (int)Math.Round(FullBackward.Value - (fraction * 16383), 0);
            return new ForwardBackwardRotation(roundedValue);
        }
    }
}
