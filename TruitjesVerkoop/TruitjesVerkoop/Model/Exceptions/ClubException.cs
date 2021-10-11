using System;

namespace BusinessLayer.Exceptions
{
    public class ClubException: Exception
    {
        public ClubException(string message) : base(message)
        {
        }

        public ClubException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
