using System;

namespace lib_NumberRows
{
    public class NotFoundReverseFactorialException : FormatException
    {
        public NotFoundReverseFactorialException() { }

        public NotFoundReverseFactorialException(string message) : base(message) { }

        public NotFoundReverseFactorialException(string message, FormatException inner) : base(message, inner) { }

    }
}
