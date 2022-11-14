using System;

namespace SnappetChallenge.Client.Exceptions
{
    public class RequestException : Exception
    {
        public RequestException() : base()
        {
        }

        public RequestException(string message) : base(message)
        {
        }

        public RequestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
