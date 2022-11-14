namespace SnappetChallenge.Client.Model
{
    public class JsonWrapper<T>
    {
        public JsonWrapper()
        {
            Success = true;
        }

        public T Content { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

    }
}