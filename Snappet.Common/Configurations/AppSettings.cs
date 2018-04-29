using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Snappet.Common.Configurations
{
    public static class AppSettings
    {
        //public static bool TryGet<T>(string key, out T value)
        //{
        //    var stringValue = Configuration[key];

        //    if (string.IsNullOrEmpty(stringValue))
        //    {
        //        value = default(T);
        //        return false;
        //    }

        //    value = (T)Convert.ChangeType(stringValue, typeof(T));
        //    return true;
        //}

        //public static T SafeGet<T>(string key)
        //{
        //    T value;
        //    if (!TryGet(key, out value))
        //        return default(T);

        //    return value;
        //}
    }
}
