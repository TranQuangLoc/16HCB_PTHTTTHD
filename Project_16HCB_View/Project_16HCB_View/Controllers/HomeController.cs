using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB_View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["login"] != null)
            {
                var rs = (List<ACCOUNT>)TempData["login"];
                return View(rs);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}