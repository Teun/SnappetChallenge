using System.Web;
using System.Web.Optimization;

namespace SnappetChallenge.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/libs/bootstrap-timepicker.js",
                      "~/Scripts/libs/bootstrap-datepicker.min.js",
                      "~/Scripts/libs/bootstrap-datepicker.nl.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap-fixed-sidebar.css",

                      "~/Content/libs/bootstrap-timepicker.css",
                      "~/Content/libs/bootstrap-datepicker3.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/libs/knockout-3.3.0.js",
                "~/Scripts/libs/knockout.mapping-latest.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/libs/moment-with-locales.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                "~/Scripts/libs/highcharts/highcharts.js"));

            bundles.Add(new ScriptBundle("~/bundles/snappetChallenge").IncludeDirectory("~/Scripts", "sc*", false));
        }
    }
}
