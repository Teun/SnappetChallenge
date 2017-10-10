using CsvHelper.TypeConversion;
using System;

namespace SnappetChallenge.Data.IO
{
    public class DifficultyConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(double);
        }

        public object ConvertFromString(TypeConverterOptions options, string text)
        {
            try
            {
                return double.Parse(text);
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public string ConvertToString(TypeConverterOptions options, object value)
        {
            throw new NotImplementedException();
        }
    }
}