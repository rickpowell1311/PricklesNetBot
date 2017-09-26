using System;

namespace PricklesNetBot.Infrastructure
{
    public static class DoubleExtensions
    {
        public static double FromDegreesToRadians(this double val)
        {
            var raw = (val * Math.PI) / 180;

            return raw.NormalizeRadialAngle();
        }

        public static double NormalizeRadialAngle(this double val)
        {

            while (val > 2 * Math.PI)
            {
                val = val - (2 * Math.PI);
            }

            while (val < 0)
            {
                val = val + (2 * Math.PI);
            }

            return val;
        }

        public static double NormalizeDegreeAngle(this double val)
        {
            while (val > 360)
            {
                val = val - 360;
            }

            while (val < 0)
            {
                val = val + 360;
            }

            return val;
        }

        public static double FromRadiansToDegrees(this double val)
        {
            var raw = (val * 180) / Math.PI;
            

            return raw.NormalizeDegreeAngle();
        }
    }
}
