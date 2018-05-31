using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_16HCB_View
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Quan ly sinh vien
            routes.MapRoute(
                name: "quan-ly-sinh-vien",
                url: "quan-ly-sinh-vien",
                defaults: new { controller = "Student", action = "ManageStudent" }
            );

            routes.MapRoute(
                name: "quan-ly-sinh-vien/them",
                url: "quan-ly-sinh-vien/them",
                defaults: new { controller = "Student", action = "StudentInsert" }
            );

            routes.MapRoute(
                name: "quan-ly-sinh-vien/cap-nhat",
                url: "quan-ly-sinh-vien/cap-nhat/{strStudentID}",
                defaults: new { controller = "Student", action = "StudentUpdate", strStudentID = UrlParameter.Optional }
            );
            #endregion

            routes.MapRoute(
                name: "TrangChu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "TrangChu", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "PhieuDiem",
            //    url: "{controller}/{action}/{id}/{mamh}",
            //    defaults: new { controller = "TrangChu", action = "TrangChu", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
