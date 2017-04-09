using System;

namespace TutorBoard.Dal.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
