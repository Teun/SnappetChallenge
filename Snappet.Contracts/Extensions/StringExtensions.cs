using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Extensions
{
    public static class StringExtensions
    {
        public static double ConvertToDouble(this string value)
        {
            if (value == "NULL")
                return 1.0;

            return Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
