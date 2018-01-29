using System;

namespace SnappetTest.Service.Infrastructure.Abstract
{
    public interface IFetchRequestedDateProvider
    {
        string RequestedDate(DateTime giveDate);
    }
}
