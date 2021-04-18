using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace ApiService.Services
{
    public static class DateTimeFormats
    {
        public const string DEFAULT_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";

        public static ReadOnlyCollection<string> DeclaredFormats { get; }

        static DateTimeFormats()
        {
            var formats = new List<string> { DEFAULT_DATETIME_FORMAT, DEFAULT_DATE_FORMAT };
            DeclaredFormats = new ReadOnlyCollection<string>(formats);
        }

        public static bool TryParse(string val, out DateTime dt)
        {
            return DateTime.TryParseExact(val, DeclaredFormats.ToArray(), CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
        }
    }
}
