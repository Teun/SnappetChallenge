using System;

namespace Snappet.Borisov.Test.Domain
{
    public class DateTimeProvider : IProvideDateTime
    {
        public DateTimeOffset Now()
        {
            return DateTimeOffset.Parse("2015-03-24T11:30:00+000");
        }
    }
}