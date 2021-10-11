using System;

namespace BusinessLayer.Exceptions
{
    public class CompetitieException : Exception
    {
        public CompetitieException(string message) : base(message)
        {
        }

        public CompetitieException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
