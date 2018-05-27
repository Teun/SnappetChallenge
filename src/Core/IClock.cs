using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Core
{
    public interface IClock
    {
        DateTime Now { get; }
    }

    public class Clock : IClock
    {
        public DateTime Now
        {
            get { return new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc); }
        }
    }
}
