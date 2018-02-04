using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared.Helpers
{
  using System.Web.Hosting;

  public abstract class PathProvider
  {
    /// <summary>
    /// If not overridden it will work with local path
    /// </summary>
    /// <returns></returns>
    public virtual string GetPath()
    {
      return HttpContext.Current.Server.MapPath(@"/App_Data/work.json");
    }
  }
}