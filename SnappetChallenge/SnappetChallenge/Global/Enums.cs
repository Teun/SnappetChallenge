using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Global
{
	public enum TimePeriodEnum
	{
		Month = 0,
		Week = 1,
		Today = 2
	}
	
	public enum DataLevelEnum
	{
		TimePeriod,
		Subject,
		Domain,
		LearningObjective
	}
}