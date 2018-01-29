using SnappetTest.Service.Infrastructure.Abstract;
using System;


namespace SnappetTest.Service.Infrastructure.Implementation
{
    public class FetchRequestedDate : IFetchRequestedDateProvider
    {
        public string RequestedDate(DateTime giveDate)
        {
            return giveDate.ToString();
        }
    }
}
