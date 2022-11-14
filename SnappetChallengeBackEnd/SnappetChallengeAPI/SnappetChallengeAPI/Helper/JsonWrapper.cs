using SnappetChallengAPI.Exceptions;

namespace SnappetChallengAPI.Helper
{
    public class JsonWrapper
    {
        public JsonWrapper()
        {
            Content = null;
            Success = true;
        }

        public JsonWrapper(object content)
        {
            Content = content;
            Success = true;
        }

        public JsonWrapper(BaseException wrappedException)
        {
            CorrelationId = wrappedException.CorrelationId;
            ErrorMessage = wrappedException.Message;
            StackTrace = wrappedException.ShowStackTrace ? wrappedException.StackTrace ?? wrappedException.InnerException?.StackTrace : null;
            ShowCorrelationId = wrappedException.ShowCorrelationId;
            Success = false;
            FriendlyError = false;
            ShowStackTrace = wrappedException.ShowStackTrace;
            HideCloseButton = wrappedException.HideCloseButton;

            if (wrappedException is FriendlyException)
            {
                var fex = wrappedException as FriendlyException;
                FriendlyError = true;
                ErrorCode = fex.ErrorCode;
            }
        }

        public object Content { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public bool FriendlyError { get; set; }

        public bool ShowStackTrace { get; set; }

        public bool ShowCorrelationId { get; set; }

        public bool HideCloseButton { get; set; }

        public int ErrorCode { get; set; }

        public Guid CorrelationId { get; set; }
    }

}
