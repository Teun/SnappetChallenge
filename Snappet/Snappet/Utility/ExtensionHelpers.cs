using System;
using NodaTime;

namespace Snappet.Utility
{
	public static class ExtensionHelpers
	{
		public static DateTime UtcToZoned(this DateTime dateTime, string usersTimezoneId )
		{
			var instant = Instant.FromDateTimeUtc(dateTime);
			var timeZoneProvider = DateTimeZoneProviders.Tzdb;
			var usersTimezone = timeZoneProvider[usersTimezoneId];
			var usersZonedDateTime = instant.InZone(usersTimezone);
			return usersZonedDateTime.ToDateTimeUnspecified();
		}
	}
}