using System.Web;
using System.Web.Optimization;

namespace MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor_js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Content/vendor_js/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/vendor_js/jquery.unobtrusive*",
                        "~/Content/vendor_js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/vendor_js/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include( 
                        "~/Content/vendor_css/reset.css",
                      "~/Content/vendor_css/style.css",
                      "~/Content/vendor_css/register.css",
                      "~/Content/vendor_css/Site.css",
                      "~/Content/vendor_css/bootstrap-paper.css",
                      "~/Content/application_css/loadtimesheet.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/vendor_js/jquery.ui.core.css",
                        "~/Content/vendor_js/jquery.ui.resizable.css",
                        "~/Content/vendor_js/jquery.ui.selectable.css",
                        "~/Content/vendor_js/jquery.ui.accordion.css",
                        "~/Content/vendor_js/jquery.ui.autocomplete.css",
                        "~/Content/vendor_js/jquery.ui.button.css",
                        "~/Content/vendor_js/jquery.ui.dialog.css",
                        "~/Content/vendor_js/jquery.ui.slider.css",
                        "~/Content/vendor_js/jquery.ui.tabs.css",
                        "~/Content/vendor_js/jquery.ui.datepicker.css",
                        "~/Content/vendor_js/jquery.ui.progressbar.css",
                        "~/Content/vendor_js/jquery.ui.theme.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",                                            
                      "~/Content/vendor_js/index.js",
                      "~/Content/vendor_js/Side-bar.js"
                      ));
    }
    }
}