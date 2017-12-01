using System.Web;
using System.Web.Optimization;

namespace Snappet.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-3.2.1.min.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/jquery.floatThead.min.js",
                        "~/Scripts/home.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/jquery-ui.min.css",
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));
        }
    }
}
