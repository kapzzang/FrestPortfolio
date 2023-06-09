using System.Web;
using System.Web.Optimization;

namespace proTnsWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            string kendoJs = "~/Resources/kendo/Js/";
            string kendoCss = "~/Resources/kendo/Css/";
            string frestJs = "~/Resources/frest/app-assets/js/";
            string frestCss = "~/Resources/frest/app-assets/css/";
            string frestVendorJs = "~/Resources/frest/app-assets/vendors/js/";
            string frestVendorCss = "~/Resources/frest/app-assets/vendors/css/";
            string frestFontsJs = "~/Resources/frest/app-assets/fonts/LivIconsEvo/js/";


            //kendo

            bundles.Add(new ScriptBundle("~/kendo/script")
            .Include(kendoJs + "jquery.json.js")
            .Include(kendoJs + "jquery.serialize-object.min.js")
            .Include(kendoJs + "jszip.min.js")
            .Include(kendoJs + "kendo.all.min.js")
            .Include(kendoJs + "kendo.modernizr.custom.js"));

            bundles.Add(new StyleBundle("~/kendo/style")
            .Include(kendoCss + "kendo.common-bootstrap.min.css")
            .Include(kendoCss + "kendo.silver.min.css")
            .Include(kendoCss + "kendo.silver.mobile.min.css")
            .Include(kendoCss + "_KendoCommon.css"));

            //frest

            //css
            bundles.Add(new StyleBundle("~/frest/css/allStyle")
            .IncludeDirectory(frestCss, "*.css", true));

            bundles.Add(new StyleBundle("~/frest/css/basic")
            .Include("~/Resources/frest/assets/css/style.css") //사용자 정의 css (2021.04.21.기준 폰트 전체 적용때문에 추가함)
            .Include(frestCss + "bootstrap.min.css")
            .Include(frestCss + "bootstrap-extended.min.css")
            .Include(frestCss + "colors.min.css")
            .Include(frestCss + "components.min.css"));

            bundles.Add(new StyleBundle("~/frest/css/theme")
            .Include(frestCss + "themes/dark-layout.min.css")
            .Include(frestCss + "themes/semi-dark-layout.min.css"));

            bundles.Add(new StyleBundle("~/frest/css/core")
            .Include(frestCss + "core/menu/menu-types/vertical-menu.min.css"));

            bundles.Add(new StyleBundle("~/frest/css/page")
            .Include(frestCss + "pages/dashboard-ecommerce.min.css"));

            bundles.Add(new StyleBundle("~/frest/css/vendor")
            .Include(frestVendorCss + "vendors.min.css")
            .Include(frestVendorCss + "charts/apexcharts.css")
            .Include(frestVendorCss + "extensions/swiper.min.css")
            .Include(frestVendorCss + "extensions/sweetalert2.min.css") //2021-08-31-강승호 - sweetalert 추가
            .Include("~/Resources/frest/assets/css/animate.min.css")//2021-08-31-강승호 - sweetalert 추가
            );

            //js
            bundles.Add(new ScriptBundle("~/frest/js/allScript")
           .IncludeDirectory(frestJs, "*.js", true));

            bundles.Add(new ScriptBundle("~/frest/js/basic")
            .Include(frestJs + "core/libraries/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/frest/js/vendor")
            .Include(frestVendorJs + "vendors.min.js")
            .Include(frestVendorJs + "charts/apexcharts.min.js")
            .Include(frestVendorJs + "extensions/swiper.min.js")
            .Include(frestVendorJs + "extensions/sweetalert2.all.min.js")//2021-08-31-강승호 - sweetalert 추가
            .Include(frestVendorJs + "extensions/polyfill.min.js")//2021-08-31-강승호 - sweetalert 추가
            );

            bundles.Add(new ScriptBundle("~/frest/js/fonts")
            .Include(frestFontsJs + "LivIconsEvo.tools.min.js")
            .Include("~/Resources/frest/assets/fonts/LivIconsEvo/js/LivIconsEvo.defaults.min.js") //경로 수정을 위해 사용자 정의로 변경
            .Include(frestFontsJs + "LivIconsEvo.min.js"));

            bundles.Add(new ScriptBundle("~/frest/js/theme")
            .Include(frestJs + "scripts/configs/vertical-menu-light.min.js")
            .Include(frestJs + "core/app-menu.min.js")
            .Include(frestJs + "core/app.min.js")
            .Include(frestJs + "scripts/components.min.js")
            .Include(frestJs + "scripts/footer.min.js")
            .Include(frestJs + "scripts/customizer.min.js"));

            bundles.Add(new ScriptBundle("~/frest/js/page")
            .Include(frestJs + "scripts/pages/dashboard-ecommerce.min.js")
            .Include(frestJs + "scripts/pages/dashboard-analytics.min.js")
            );

            //대시보드 전용
            bundles.Add(new StyleBundle("~/frest/css/dashBoard")
            .Include("~/Resources/frest/assets/css/dashBoardStyle.css")
            );

            //commonPage 전용
            bundles.Add(new StyleBundle("~/frest/css/commonPage")
            .Include(frestVendorCss + "forms/select/select2.min.css")
            .Include(frestVendorCss + "pickers/daterange/daterangepicker.css")
            );
            bundles.Add(new ScriptBundle("~/frest/js/commonPage")
            .Include(frestVendorJs + "forms/select/select2.full.min.js")
            .Include(frestVendorJs + "extensions/moment.min.js")
            .Include(frestVendorJs + "pickers/daterange/daterangepicker.js")
            );

            //form-validation 관련
            bundles.Add(new StyleBundle("~/frest/css/validation")
            .Include(frestCss + "plugins/forms/validation/form-validation.css")
            );
            bundles.Add(new ScriptBundle("~/frest/js/validation")
            .Include(frestVendorJs + "forms/validation/jquery.validate.min.js")
            );

            //form-Wizard 관련
            bundles.Add(new StyleBundle("~/frest/css/wizard")
            .Include(frestCss + "plugins/forms/wizard.min.css")
            );
            bundles.Add(new ScriptBundle("~/frest/js/wizard")
            .Include(frestVendorJs + "extensions/jquery.steps.min.js")
            .Include(frestVendorJs + "forms/validation/jquery.validate.min.js")
            );

            //picker 관련(시간)
            bundles.Add(new StyleBundle("~/frest/css/picker")
            .Include(frestVendorCss + "pickers/pickadate/pickadate.css")
            );
            bundles.Add(new ScriptBundle("~/frest/js/picker")
            .Include(frestVendorJs + "pickers/pickadate/picker.js")
            .Include(frestVendorJs + "pickers/pickadate/picker.date.js")
            .Include(frestVendorJs + "pickers/pickadate/picker.time.js")
            .Include(frestVendorJs + "pickers/pickadate/legacy.js")
            );

            //dropzone 첨부파일 업로드
            bundles.Add(new StyleBundle("~/frest/css/dropzone")
            .Include("~/Resources/frest/assets/css/Dropzone/dropzone.min.css")
            );
            bundles.Add(new ScriptBundle("~/frest/js/dropzone")
            .Include("~/Resources/frest/assets/js/Dropzone/dropzone.min.js")            
            );
        }
    }
}
