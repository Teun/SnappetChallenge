using System.Web.Optimization;

namespace Snappet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
	    public static void RegisterBundles(BundleCollection bundles)
	    {
		    bundles.Add(new StyleBundle("~/Content/css").Include(
			    "~/Content/bootstrap.css",
			    "~/Content/site.css"));

		    bundles.Add(new ScriptBundle("~/bundles/snappet").Include(
			    "~/Scripts/jquery-1.10.2.js"
			    , "~/Scripts/jquery.cookie.js"
			    //,"~/Scripts/modernizr-2.6.2.js"
			    //,"~/Scripts/bootstrap.js"
			    , "~/Scripts/highcharts.src.js"
			    , "~/Scripts/jstz.main.js"
			    , "~/Scripts/jstz.main.js"));
	    }
    }
}
