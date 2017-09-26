using PricklesNetBot.Infrastructure;
using System;

namespace PricklesNetBot.Domain
{
    public class Vector
    {
        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public double TwoDimensionalLength
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double TwoDimensionalProduct(Vector other)
        {
            return X * other.Y - Y * other.X;
        }

        public double TwoDimensionalDotProductWith(Vector other)
        {
            return X * other.X + Y * other.Y;
        }

        public double AngleBetween(Vector other)
        {
            var dotProduct = this.TwoDimensionalDotProductWith(other);
            var lengthsProduct = this.TwoDimensionalLength * other.TwoDimensionalLength;

            var raw = Math.Acos(dotProduct / lengthsProduct).FromRadiansToDegrees();

            if (this.TwoDimensionalProduct(other) < 0)
            {
                raw = 360 - raw;
            }

            return Math.Round(raw, 6);
        }
    }
}
