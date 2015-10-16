using System;
using System.Globalization;

namespace Web.Helpers
{
	public class DateTimeHelper
	{
		public static int GetWeekNumber(DateTime dateTime)
		{
			//ISO8601
			DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);

			if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
			{
				dateTime = dateTime.AddDays(3);
			}

			// Return the week of our adjusted day
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}

	}
}