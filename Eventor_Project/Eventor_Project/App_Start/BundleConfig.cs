using System.Web.Optimization;

namespace Eventor_Project
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include("~/Scripts/moment*"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap*", "~/Content/Site.css", "~/Content/bootstrap-datetimepicker.css"));
        }
    }
}