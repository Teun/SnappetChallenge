using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Core
{
    public static class Extensions
    {
        public static double SafeParseDouble(this string value)
        {
            double result;
            if (double.TryParse(value, out result))
                return result;

            return 0;
        }
    }
}
