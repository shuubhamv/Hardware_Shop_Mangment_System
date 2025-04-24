using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Fix: Separate MyDetails from Details
        routes.MapRoute(
            name: "CustomerMyDetails",
            url: "MyDetails",
            defaults: new { controller = "Customer", action = "MyDetails" }
        );

        // Customer Details Route (for ID-based details)
        routes.MapRoute(
            name: "CustomerDetails",
            url: "Customer/Details/{id}",
            defaults: new { controller = "Customers", action = "Details", id = UrlParameter.Optional }
        );

        // Admin Dashboard Route
        //routes.MapRoute(
        //    name: "Admin",
        //    url: "Admin/Dashboard",
        //    defaults: new { controller = "Admin", action = "AIndex" }
        //);

        // Employee Dashboard Route
        //routes.MapRoute(
        //    name: "Employee",
        //    url: "Employee/Dashboard",
        //    defaults: new { controller = "items", action = "Index" }
        //);

        // Account Register Route
        routes.MapRoute(
            name: "Register",
            url: "Account/Register",
            defaults: new { controller = "Account", action = "Register" }
        );

        // Default Route (Keep this last)
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
        );
    }
}
