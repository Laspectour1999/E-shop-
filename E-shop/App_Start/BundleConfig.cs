﻿using System.Web;
using System.Web.Optimization;

namespace E_shop
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

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.bundle.js")); // Bootstrap 5 + Popper

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrapFF.css", // Ensure this is Bootstrap 5
                        "~/Content/site.css"));
        }
    }
}
