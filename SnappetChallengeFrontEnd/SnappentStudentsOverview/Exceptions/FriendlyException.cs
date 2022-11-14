using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallenge.Client.Exceptions
{
    public class FriendlyException : Exception
    {
        public FriendlyException() : base()
        {
        }

        public FriendlyException(string message) : base(message)
        {
        }

        public FriendlyException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
