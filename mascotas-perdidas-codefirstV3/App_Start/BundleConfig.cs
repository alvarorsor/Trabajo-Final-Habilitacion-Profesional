using System.Web;
using System.Web.Optimization;

namespace mascotas_perdidas_codefirstV3
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
             bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

             bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate*"));

             // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
             // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                         "~/Scripts/modernizr-*"));

             bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"));

             bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css"));

            /*
                        bundles.Add(new Bundle("~/bundles/jquery").Include(
                                   "~/Scripts/jquery-{version}.js"));

                        bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                                    "~/Scripts/jquery.validate*"));

                        // Use the development version of Modernizr to develop with and learn from. Then, when you're
                        // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
                        bundles.Add(new Bundle("~/bundles/modernizr").Include(
                                    "~/Scripts/modernizr-*"));

                        bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                                  "~/Scripts/bootstrap.min.js"
                                  ));

                        bundles.Add(new Bundle("~/Content/css").Include(
                                  "~/Content/bootstrap.css",
                                  "~/Content/bootstrap.min.css",
                                  "~/Content/Styles.css"));*/
        }
    }
    }
