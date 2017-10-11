using System.Web;
using System.Web.Optimization;

namespace Core.Web
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
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminLTE").Include(
                     "~/Scripts/adminLTE/app.js",
                     "~/Scripts/adminLTE/jquery-ui-1.10.3.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/adminLTE").Include(
                      "~/Content/adminLTE/css/font-awesome.css",
                       "~/Content/adminLTE/css/ionicons.css",
                       "~/Content/adminLTE/css/adminLTE.css"));
        }
    }
}
