using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB_View.Controllers
{
    public class GlobalController : Controller
    {
        // GET: Global
        public PartialViewResult PartialViewMenu()
        {
            return PartialView();
        }

        public PartialViewResult PartialViewTrangChu()
        {
            if (TempData["login"] != null)
            {
                ViewBag.user = TempData["login"];
            }

            return PartialView();
        }

        public PartialViewResult PartialViewTinTuc()
        {
            return PartialView();
        }

        public PartialViewResult PartialViewChuongTrinhDaoTao()
        {
            return PartialView();
        }
    }
}