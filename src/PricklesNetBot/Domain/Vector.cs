using System;

namespace PricklesNetBot.Domain
{
    public class Vector : IEquatable<Vector>
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

        public Vector Subtract(Vector other)
        {
            return new Vector(X - other.X, Y - other.Y, Z - other.Z);
        }

        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y, Z + other.Z);
        }

        public Vector ScalarMultiply(double factor)
        {
            return new Vector(X * factor, Y * factor, Z * factor);
        }

        public double TwoDimensionalProduct(Vector other)
        {
            return X * other.Y - Y * other.X;
        }

        public double TwoDimensionalDotProductWith(Vector other)
        {
            return X * other.X + Y * other.Y;
        }

        public Angle TwoDimensionalShortestAngleBetween(Vector other)
        {
            var dotProduct = this.TwoDimensionalDotProductWith(other);
            var lengthsProduct = this.TwoDimensionalLength * other.TwoDimensionalLength;

            return Angle.FromRadians(Math.Acos(dotProduct / lengthsProduct));
        }

        public Angle TwoDimensionalAngleBetween(Vector other)
        {
            var angle = this.TwoDimensionalShortestAngleBetween(other);

            if (this.TwoDimensionalProduct(other) < 0)
            {
                angle = angle.Invert();
            }

            return angle;
        }

        public bool Equals(Vector other)
        {
            return X == other.X
                && Y == other.Y
                && Z == other.Z;
        }
    }
}
