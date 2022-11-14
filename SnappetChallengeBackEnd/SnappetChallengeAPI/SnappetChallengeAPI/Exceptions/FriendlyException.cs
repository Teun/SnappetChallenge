namespace SnappetChallengAPI.Exceptions
{
    public class FriendlyException : BaseException
    {
        public FriendlyException() : base()
        {
            ErrorCode = 1000;
            CorrelationId = Guid.NewGuid();
            ShowStackTrace = true;
            HideCloseButton = false;
        }

        public FriendlyException(string message) : base(message)
        {
            ErrorCode = 1000;
            CorrelationId = Guid.NewGuid();
            ShowStackTrace = true;
            HideCloseButton = false;
        }

        public FriendlyException(string message, Exception inner) : base(message, inner)
        {
            ErrorCode = 1000;
            CorrelationId = Guid.NewGuid();
            ShowStackTrace = true;
            HideCloseButton = false;
        }
    }
}
