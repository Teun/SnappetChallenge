using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Repositories.Exceptions
{
    public class NoWorkFileException : Exception
    {
        public NoWorkFileException()
        {
        }

        public NoWorkFileException(string message) : base(message)
        {
        }

        public NoWorkFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoWorkFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
