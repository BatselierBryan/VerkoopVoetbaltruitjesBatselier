using System;

namespace BusinessLayer.Exceptions
{
    public class ClubSetException : Exception
    {
        public ClubSetException(string message) : base(message)
        {
        }

        public ClubSetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
