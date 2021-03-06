using System;

namespace BusinessLayer.Exceptions
{
    public class KlantException : Exception
    {
        public KlantException(string message) : base(message)
        {
        }

        public KlantException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
