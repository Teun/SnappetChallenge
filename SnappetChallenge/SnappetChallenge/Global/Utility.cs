using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Global
{
	public class Utility
	{

		//Work out starting time based on what time period we have selected
		public static DateTime GetStartDateTime(TimePeriodEnum timePeriod, DateTime currentDateTime)
		{

			//Default value will be the start of today
			DateTime startDateTime = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 0, 0, 0);

			switch (timePeriod)
			{
				case TimePeriodEnum.Week:
					startDateTime = startDateTime.AddDays(-7);
					break;
				case TimePeriodEnum.Month:
					startDateTime = startDateTime.AddDays((startDateTime.Day - 1) * -1); //Set to the 1st of the current month
					break;
			}
			return startDateTime;
		}
	}
}