using System.Web;
using System.Web.Optimization;

namespace SnappetChallenge.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Scripts/jquery/jquery-3.2.1.min",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/Scripts/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/core-plugin").Include(
                        "~/Scripts/jquery-easing/jquery.easing.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));          

            bundles.Add(new ScriptBundle("~/bundles/sb-admin").Include(
                "~/Scripts/sb-admin.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/font-awesome/css/font-awesome.min.css",
                "~/Content/sb-admin.css"));
        }
    }
}
