using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallenge.Client.Exceptions
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException() : base()
        {
        }

        public RequestFailedException(string message) : base(message)
        {
        }

        public RequestFailedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
