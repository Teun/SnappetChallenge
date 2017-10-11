using CsvHelper.TypeConversion;
using System;

namespace SnappetChallenge.Data.IO
{
    class BooleanTypeConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(bool);
        }

        public object ConvertFromString(TypeConverterOptions options, string text)
        {
            return text.Equals("1");
        }

        public string ConvertToString(TypeConverterOptions options, object value)
        {
            throw new NotImplementedException();
        }
    }
}
