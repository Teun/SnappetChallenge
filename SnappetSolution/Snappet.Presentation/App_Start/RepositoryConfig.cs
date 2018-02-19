using Snappet.Infrastructure.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Presentation.App_Start
{
	public static class RepositoryConfig
	{
		public static void LoadRepository()
		{
			var repository = DependencyResolver.Current.GetService<IMemoryReadOnlyRepository>();
			repository.LoadData(HttpContext.Current.Server.MapPath("~/App_Data/work.json.txt"));
		}
	}
}