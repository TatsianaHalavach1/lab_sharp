using System;

namespace lib_Point
{
    public class Point : IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            if (IsValidCoordinate(x))
            {
                X = x;
            }
            else
            {
                throw new PointCoordinateException("Incorrect coordinate X=" + x);
            }
            if (IsValidCoordinate(y))
            {
                Y = y;
            }
            else
            {
                throw new PointCoordinateException("Incorrect coordinate Y=" + y);
            }
        }

        private bool IsValidCoordinate(double coordinate) => double.MinValue <= coordinate && coordinate <= double.MaxValue;

        //Distance between 2 points
        public double DistanceTo(Point otherPoint)
        {
            return Math.Sqrt(Math.Pow(X - otherPoint.X, 2) + Math.Pow(Y - otherPoint.Y, 2));
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}
