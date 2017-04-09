using System;

namespace TutorBoard.Dal.Providers
{
    public class FakeDateTimeProvider : IDateTimeProvider
    {
        private readonly DateTime _now;
        public FakeDateTimeProvider(DateTime fakeNow)
        {
            _now = fakeNow;
        }

        public DateTime UtcNow { get { return _now; } }
    }
}
