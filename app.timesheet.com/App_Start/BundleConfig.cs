using System.Web;
using System.Web.Optimization;

namespace app.timesheet.com {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.js",
                      "~/assets/plugins/Datatables/datatables.min.js",
                      "~/assets/plugins/notyf/notyf.min.js",
                      "~/assets/plugins/Select2/js/select2.min.js",
                      "~/assets/plugins/timepicker/jquery.timepicker.min.js",
                      "~/assets/js/app.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/assets/plugins/Datatables/datatables.min.css",
                      "~/assets/plugins/notyf/notyf.min.css",
                      "~/assets/plugins/Select2/css/select2.min.css",
                      "~/assets/plugins/timepicker/jquery.timepicker.min.css",
                      "~/Content/dark.css",
                      "~/assets/css/app.css"));
        }
    }
}
