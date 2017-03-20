using System;
using System.Globalization;

namespace Services.Parsers
{
    public static class DifficultyParser
    {
        private const string NullValue = "NULL";

        public static decimal? Parse(string difficulty)
        {
            if (string.IsNullOrWhiteSpace(difficulty) ||
                string.Equals(difficulty, NullValue, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            decimal parsedDifficulty;
            if (!decimal.TryParse(difficulty, NumberStyles.Number, CultureInfo.InvariantCulture, out parsedDifficulty))
            {
                return null;
            }

            return parsedDifficulty;
        }
    }
}
