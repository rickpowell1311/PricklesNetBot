using PricklesNetBot.Domain.Constants;
using System;

namespace PricklesNetBot.Domain.IO
{
    public class Turn : IEquatable<Turn>
    {
        public int Value { get; private set; }

        public static Turn FullLeft
        {
            get
            {
                return new Turn(0);
            }
        }

        public static Turn FullRight
        {
            get
            {
                return new Turn(32767);
            }
        }

        public static Turn None
        {
            get
            {
                return new Turn(16383);
            }
        }

        public Turn(int value)
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

        public static Turn CustomFractionLeft(double fraction)
        {
            var roundedValue = (int)Math.Round(fraction * 16383, 0);
            return new Turn(roundedValue);
        }

        public static Turn CustomFractionRight(double fraction)
        {
            var roundedValue = (int)Math.Round(FullRight.Value - (fraction * 16383), 0);
            return new Turn(roundedValue);
        }

        public bool Equals(Turn other)
        {
            return other != null &&
                Value == other.Value;
        }
    }
}
