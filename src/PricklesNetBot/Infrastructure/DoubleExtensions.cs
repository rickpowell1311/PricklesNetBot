using System;

namespace PricklesNetBot.Infrastructure
{
    public static class DoubleExtensions
    {
        public static double FromDegreesToRadians(this double val)
        {
            var raw = (val * Math.PI) / 180;
            if (raw < 0)
            {
                raw = raw + (2 * Math.PI);
            }

            return raw;
        }

        public static double FromRadiansToDegrees(this double val)
        {
            var raw = (val * 180) / Math.PI;
            if (raw < 0)
            {
                raw = raw + (2 * Math.PI);
            }

            return raw;
        }
    }
}
