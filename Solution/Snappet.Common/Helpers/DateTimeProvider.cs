using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Common.Helpers
{
    public class DateTimeProvider : IDateTimeProvider
    {
       
        DateTime IDateTimeProvider.Now { 
            get => 
                new DateTime(2015, 03, 24, 11, 30, 0, DateTimeKind.Utc); 
        }
    }
}
