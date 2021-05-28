using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Common.Helpers
{
    public interface IDateTimeProvider 
    {
        DateTime Now { get;}
    }
}
