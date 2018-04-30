using System.Web;
using System.Web.Optimization;

namespace SnappetChallenge
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/pikaday.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/appscriptfiles").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/loader.js",
                "~/Scripts/pikaday.js",
                "~/Scripts/App/Scripts/App.js",
                "~/Scripts/App/Scripts/Dashboard.Controller.js",
                "~/Scripts/App/Scripts/Service.Exercises.js",
                "~/Scripts/App/Scripts/Summary.Controller.js"));
        }
    }
}
