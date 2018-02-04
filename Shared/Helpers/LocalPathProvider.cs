using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared.Helpers
{
  public class LocalPathProvider : PathProvider
  {
    public override string GetPath()
    {
      return "~/../../../../StudyResultsAnalysis/App_Data/work.json";
    }
  }
}