using System;

namespace Report
{
    public interface IDateProvider
    {
        DateTime Now { get; }
    }
}
