using System.Linq;

namespace SnappetChallenge.CrossCutting.Models
{
    public class Envelope<T>
    {
        public Envelope(T content, string[] errors)
        {
            Content = content;
            Errors = errors ?? new string[] { };
        }

        public T Content { get; private set; }

        public bool IsSuccess => Errors?.Any() == false;
        public string[] Errors { get; private set; }

        public static Envelope<T> Error(string[] errors, T content = default(T)) => new Envelope<T>(content, errors);
        public static Envelope<T> Success(T content) => new Envelope<T>(content, null);
    }
}
