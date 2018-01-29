using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetTest.Model.Abstract
{
    public  interface ITimeStamp
    {
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
