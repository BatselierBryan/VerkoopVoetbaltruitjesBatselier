using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Exceptions
{
    public class ClubsetException : Exception
    {
        public ClubsetException(string message) : base(message)
        {
        }

        public ClubsetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
