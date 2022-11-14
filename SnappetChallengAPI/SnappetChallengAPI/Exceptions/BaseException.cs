namespace SnappetChallengAPI.Exceptions
{
    public class BaseException : Exception
    {
        public Guid CorrelationId { get; set; }

        public int ErrorCode { get; set; }

        public bool ShowStackTrace { get; set; }

        public bool HideCloseButton { get; set; }

        public bool ShowCorrelationId { get; set; }

        public BaseException()
        {
            setProps();
        }

        public BaseException(string message) : base(message)
        {
            setProps();
        }

        public BaseException(Exception ex) : base(ex.Message, ex)
        {
            setProps();
        }

        public BaseException(string message, Exception ex) : base(message, ex)
        {
            setProps();
        }

        private void setProps()
        {
            CorrelationId = Guid.NewGuid();
            ShowStackTrace = true;
            HideCloseButton = false;
            ShowCorrelationId = true;
        }
    }
}
