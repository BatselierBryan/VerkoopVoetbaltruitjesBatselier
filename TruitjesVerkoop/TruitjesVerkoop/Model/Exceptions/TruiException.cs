using System;

namespace BusinessLayer.Exceptions
{
    public class TruiException : Exception
    {
        public TruiException(string message) : base(message)
        {
        }

        public TruiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
