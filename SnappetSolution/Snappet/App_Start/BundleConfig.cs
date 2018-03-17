using System.Web;
using System.Web.Optimization;

namespace Snappet
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/vendorscripts").Include(
                      "~/Scripts/Vendors/vue.js",
                      "~/Scripts/Vendors/chart.js",
                      "~/Scripts/Vendors/chartkick.js",
                      "~/Scripts/Vendors/vue-chartkick.js",
                      "~/Scripts/Vendors/es6-promise.js",
                      "~/Scripts/Vendors/axios.js"));
        }
    }
}
