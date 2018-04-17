namespace SnappetChallenge.Web.Controllers
{
    using System;

    public class ResultNotFoundException : Exception
    {
        public ResultNotFoundException()
          : base()
        {
        }

        public ResultNotFoundException(String message)
          : base(message)
        {
        }

        public ResultNotFoundException(String message, Exception innerException)
          : base(message, innerException)
        {
        }
    }
}