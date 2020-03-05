﻿using System.Web;
using System.Web.Optimization;

namespace ChatWithSignalRAndWinServMVC.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquerysignalr").Include(
                      "~/Scripts/jquery.signalR-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/util").Include(
                               "~/Scripts/Home/util.js"));

            bundles.Add(new ScriptBundle("~/bundles/gtag").Include(
                               "~/Scripts/Home/gtagEvents.js"));
        }
    }
}
