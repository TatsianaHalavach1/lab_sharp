using System;

namespace lib_Point
{
    public class PointCoordinateException: FormatException
    {
        public PointCoordinateException() : base($"Custom message ") { }

        public PointCoordinateException(string message) : base($"Custom message {message}") { }

        public PointCoordinateException(string message, FormatException inner) : base(message, inner) { }

    }
}
