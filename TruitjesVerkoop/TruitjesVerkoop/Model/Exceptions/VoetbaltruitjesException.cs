using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Exceptions
{
    class VoetbaltruitjesException : Exception
    {
        public VoetbaltruitjesException(string message) : base(message)
        {
        }

        public VoetbaltruitjesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
