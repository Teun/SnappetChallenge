using AutoMapper;
using Snappet.Infrastructure.DAL.Contract;
using Snappet.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.Presentation.App_Start
{
	public static class AutomapperConfig
	{
		public static void RegisterAutomapper()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<SummaryReportViewModel, ReportRequest>();
				cfg.CreateMap<RequestColumnSettingsViewModel<int>, RequestColumnSettings<int>>();
				cfg.CreateMap<RequestColumnSettingsViewModel<string>, RequestColumnSettings<string>>();
			});
		}
	}
}