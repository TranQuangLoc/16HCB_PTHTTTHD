using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB_View.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult SendMail()
        {

            if (Session["userid"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
    }
}