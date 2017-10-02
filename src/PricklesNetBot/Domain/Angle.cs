using PricklesNetBot.Infrastructure;
using System;

namespace PricklesNetBot.Domain
{
    public class Angle : IEquatable<Angle>
    {
        private readonly AngleType type;
        private double value;

        public double Radians => type == AngleType.Degrees
            ? FromDegreesToRadians(value)
            : NormalizeRadialAngle(value);

        public double Degrees => type == AngleType.Radians
            ? FromRadiansToDegrees(value)
            : NormalizeDegreeAngle(value);

        private Angle(AngleType type, double value)
        {
            this.type = type;
            this.value = Math.Round(value, 6);
        }

        public static Angle FromRadians(double radians)
        {
            return new Angle(AngleType.Radians, radians);
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(AngleType.Degrees, degrees);
        }

        public Angle Invert()
        {
            var newValue = value;

            switch (type)
            {
                case AngleType.Degrees:
                    newValue = 360 - value;
                    break;
                case AngleType.Radians:
                    newValue = 2 * Math.PI - value;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new Angle(type, newValue);
        }

        public Vector As2dVector(TwoDimensionalVectorType vectorType)
        {
            switch (vectorType)
            {
                case TwoDimensionalVectorType.XY:
                    return new Vector(Math.Round(Math.Cos(Radians), 3), Math.Round(Math.Sin(Radians), 3), 0);
                case TwoDimensionalVectorType.XZ:
                    return new Vector(Math.Round(Math.Cos(Radians), 3), 0, Math.Round(Math.Sin(Radians), 3));
                case TwoDimensionalVectorType.YZ:
                    return new Vector(0, Math.Round(Math.Cos(Radians)), Math.Round(Math.Sin(Radians)));
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsLessThan(Angle other)
        {
            return Radians < other.Radians;
        }

        public bool IsMoreThan(Angle other)
        {
            return Radians > other.Radians;
        }

        public bool Equals(Angle other)
        {
            return Radians == other.Radians;
        }

        public Angle Multiply(double factor)
        {
            return FromDegrees(Degrees * factor);
        }

        public Angle Subtract(Angle other)
        {
            return FromDegrees(Degrees - other.Degrees);
        }

        private double FromDegreesToRadians(double val)
        {
            var raw = (val * Math.PI) / 180;

            return NormalizeRadialAngle(raw);
        }

        private double FromRadiansToDegrees(double val)
        {
            var raw = (val * 180) / Math.PI;

            return NormalizeDegreeAngle(raw);
        }

        private double NormalizeRadialAngle(double val)
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

        private double NormalizeDegreeAngle(double val)
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
    }
}
